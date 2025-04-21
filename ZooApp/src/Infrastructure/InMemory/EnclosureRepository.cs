using System;
using System.Collections.Generic;
using System.Linq;
using ZooApp.Domain.Entities;
using ZooApp.Domain.Repositories;

namespace ZooApp.Infrastructure.InMemory
{
    public class EnclosureRepository : IEnclosureRepository
    {
        private readonly List<Enclosure> _store = new();

        public Enclosure GetById(Guid id) => _store.Single(e => e.Id == id);
        public IEnumerable<Enclosure> GetAll() => _store;
        public void Add(Enclosure enclosure) => _store.Add(enclosure);
        public void Remove(Guid id) => _store.RemoveAll(e => e.Id == id);
    }
}
