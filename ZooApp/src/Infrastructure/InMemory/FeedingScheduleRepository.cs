using System;
using System.Collections.Generic;
using System.Linq;
using ZooApp.Domain.Entities;
using ZooApp.Domain.Repositories;

namespace ZooApp.Infrastructure.InMemory
{
    public class FeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly List<FeedingSchedule> _store = new();

        public FeedingSchedule GetById(Guid id) => _store.Single(s => s.Id == id);
        public IEnumerable<FeedingSchedule> GetAll() => _store;
        public void Add(FeedingSchedule schedule) => _store.Add(schedule);
        public void Remove(Guid id) => _store.RemoveAll(s => s.Id == id);
    }
}
