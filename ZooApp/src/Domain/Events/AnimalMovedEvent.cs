using System;

namespace ZooApp.Domain.Events
{
    public record AnimalMovedEvent(Guid AnimalId, Guid FromEnclosureId, Guid ToEnclosureId, DateTime OccurredAt);
}
