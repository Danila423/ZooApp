using System;
using Xunit;
using ZooApp.Application.Services;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;
using ZooApp.Infrastructure.InMemory;
using ZooApp.Infrastructure.Messaging;

namespace ZooApp.Tests.Application
{
    public class FeedingOrganizationServiceTests
    {
        [Fact]
        public void ScheduleFeeding_AddsScheduleToRepo()
        {
            var animals = new AnimalRepository();
            var schedules = new FeedingScheduleRepository();
            var bus = new InMemoryMessageBus();
            var service = new FeedingOrganizationService(schedules, animals, bus);

            var animal = new Animal(new Species("Goat"), "Gigi", DateTime.Today, Sex.Female, new FoodType("Hay"), Guid.NewGuid());
            animals.Add(animal);

            // Act
            service.ScheduleFeeding(animal.Id, DateTime.Now, "Hay");

            // Assert
            Assert.Single(schedules.GetAll());
        }

        [Fact]
        public void ExecuteFeeding_MarksScheduleCompleted()
        {
            var animals = new AnimalRepository();
            var schedules = new FeedingScheduleRepository();
            var bus = new InMemoryMessageBus();
            var service = new FeedingOrganizationService(schedules, animals, bus);

            var animal = new Animal(new Species("Rabbit"), "Rabbie", DateTime.Today, Sex.Female, new FoodType("Carrot"), Guid.NewGuid());
            animals.Add(animal);
            var schedule = new FeedingSchedule(animal.Id, DateTime.Now, new FoodType("Carrot"));
            schedules.Add(schedule);

            // Act
            service.ExecuteFeeding(schedule.Id);

            // Assert
            Assert.True(schedule.IsCompleted);
        }
    }
}
