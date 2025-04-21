using System;
using Xunit;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;

namespace ZooApp.Tests.Domain
{
    public class FeedingScheduleTests
    {
        private readonly FeedingSchedule _schedule;
        private readonly Guid _animalId = Guid.NewGuid();
        private readonly DateTime _time = DateTime.Now.AddHours(1);

        public FeedingScheduleTests()
        {
            _schedule = new FeedingSchedule(_animalId, _time, new FoodType("Grass"));
        }

        [Fact]
        public void NewSchedule_IsNotCompleted()
        {
            Assert.False(_schedule.IsCompleted);
        }

        [Fact]
        public void Reschedule_UpdatesTime()
        {
            var newTime = _time.AddHours(2);
            _schedule.Reschedule(newTime);
            Assert.Equal(newTime, _schedule.Time);
        }

        [Fact]
        public void MarkCompleted_SetsIsCompleted()
        {
            _schedule.MarkCompleted();
            Assert.True(_schedule.IsCompleted);
        }
    }
}
