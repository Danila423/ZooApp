using System;
using ZooApp.Application.Interfaces;
using ZooApp.Domain.Repositories;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;
using ZooApp.Domain.Events;
using ZooApp.Infrastructure.Messaging;
//using ZooApp.src.Infrastructure.Messaging;

namespace ZooApp.Application.Services
{
    public class FeedingOrganizationService : IFeedingOrganizationService
    {
        private readonly IFeedingScheduleRepository _schedules;
        private readonly IAnimalRepository _animals;
        private readonly InMemoryMessageBus _bus;

        public FeedingOrganizationService(
            IFeedingScheduleRepository schedules,
            IAnimalRepository animals,
            InMemoryMessageBus bus)
        {
            _schedules = schedules;
            _animals = animals;
            _bus = bus;
        }

        public void ScheduleFeeding(Guid animalId, DateTime time, string food)
        {
            var schedule = new FeedingSchedule(animalId, time, new FoodType(food));
            _schedules.Add(schedule);
        }

        public void ExecuteFeeding(Guid scheduleId)
        {
            var schedule = _schedules.GetById(scheduleId);
            var animal = _animals.GetById(schedule.AnimalId);

            animal.Feed();
            schedule.MarkCompleted();

            var @event = new FeedingTimeEvent(schedule.AnimalId, schedule.Time, DateTime.UtcNow);
            _bus.Publish(@event);
        }
    }
}
