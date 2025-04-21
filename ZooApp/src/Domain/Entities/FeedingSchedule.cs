using System;
using ZooApp.Domain.ValueObjects;
//using ZooApp.src.Application.ValueObjects;

namespace ZooApp.Domain.Entities
{
    /// <summary>
    /// Расписание кормления: животное, время, тип пищи.
    /// Методы: изменить расписание, отметить выполнение.
    /// </summary>
    public class FeedingSchedule
    {
        public Guid Id { get; private set; }
        public Guid AnimalId { get; private set; }
        public DateTime Time { get; private set; }
        public FoodType Food { get; private set; }
        public bool IsCompleted { get; private set; }

        public FeedingSchedule(Guid animalId, DateTime time, FoodType food)
        {
            Id = Guid.NewGuid();
            AnimalId = animalId;
            Time = time;
            Food = food;
            IsCompleted = false;
        }

        public void Reschedule(DateTime newTime) => Time = newTime;

        public void MarkCompleted() => IsCompleted = true;
    }
}
