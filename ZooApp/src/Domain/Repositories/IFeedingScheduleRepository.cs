using System;
using System.Collections.Generic;
using ZooApp.Domain.Entities;

namespace ZooApp.Domain.Repositories
{
    public interface IFeedingScheduleRepository
    {
        FeedingSchedule GetById(Guid id);
        IEnumerable<FeedingSchedule> GetAll();
        void Add(FeedingSchedule schedule);
        void Remove(Guid id);
    }
}
