using System;
using ZooApp.Application.Interfaces;
using ZooApp.Domain.Repositories;
using ZooApp.Domain.Events;
using ZooApp.Infrastructure.Messaging;
//using ZooApp.src.Infrastructure.Messaging;

namespace ZooApp.Application.Services
{
    public class AnimalTransferService : IAnimalTransferService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEnclosureRepository _enclosures;
        private readonly InMemoryMessageBus _bus;

        public AnimalTransferService(
            IAnimalRepository animals,
            IEnclosureRepository enclosures,
            InMemoryMessageBus bus)
        {
            _animals = animals;
            _enclosures = enclosures;
            _bus = bus;
        }

        public void Transfer(Guid animalId, Guid toEnclosureId)
        {
            var animal = _animals.GetById(animalId);
            var fromId = animal.EnclosureId;

            var from = _enclosures.GetById(fromId);
            from.RemoveAnimal();

            var to = _enclosures.GetById(toEnclosureId);
            to.AddAnimal();

            animal.MoveTo(toEnclosureId);

            var @event = new AnimalMovedEvent(animalId, fromId, toEnclosureId, DateTime.UtcNow);
            _bus.Publish(@event);
        }
    }
}
