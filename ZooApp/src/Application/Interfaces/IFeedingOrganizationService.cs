using System;

namespace ZooApp.Application.Interfaces
{
    public interface IFeedingOrganizationService
    {
        void ScheduleFeeding(Guid animalId, DateTime time, string food);
        void ExecuteFeeding(Guid scheduleId);
    }
}
