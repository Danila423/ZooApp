using System;
using Xunit;
using ZooApp.Application.Services;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;
using ZooApp.Infrastructure.InMemory;
using ZooApp.Infrastructure.Messaging;
using ZooApp.Domain.Repositories;

namespace ZooApp.Tests.Application
{
    public class AnimalTransferServiceTests
    {
        [Fact]
        public void Transfer_MovesAnimalAndUpdatesCounts()
        {
            // Arrange
            var animals = new AnimalRepository();
            var enclosures = new EnclosureRepository();
            var bus = new InMemoryMessageBus();
            var service = new AnimalTransferService(animals, enclosures, bus);

            var enc1 = new Enclosure(EnclosureType.Herbivore, 50, 2);
            var enc2 = new Enclosure(EnclosureType.Herbivore, 50, 2);
            enclosures.Add(enc1);
            enclosures.Add(enc2);

            var animal = new Animal(new Species("Zebra"), "Zed", DateTime.Today, Sex.Male, new FoodType("Grass"), enc1.Id);
            animals.Add(animal);
            enc1.AddAnimal();

            // Act
            service.Transfer(animal.Id, enc2.Id);

            // Assert
            Assert.Equal(enc2.Id, animal.EnclosureId);
            Assert.Equal(0, enc1.CurrentCount);
            Assert.Equal(1, enc2.CurrentCount);
        }
    }
}
