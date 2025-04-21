using System;

namespace ZooApp.Domain.Events
{
    public record FeedingTimeEvent(Guid AnimalId, DateTime ScheduledTime, DateTime OccurredAt);
}
