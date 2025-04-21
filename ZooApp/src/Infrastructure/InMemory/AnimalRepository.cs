using System;
using System.Collections.Generic;
using System.Linq;
using ZooApp.Domain.Entities;
using ZooApp.Domain.Repositories;

namespace ZooApp.Infrastructure.InMemory
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly List<Animal> _store = new();

        public Animal GetById(Guid id) => _store.Single(a => a.Id == id);
        public IEnumerable<Animal> GetAll() => _store;
        public void Add(Animal animal) => _store.Add(animal);
        public void Remove(Guid id) => _store.RemoveAll(a => a.Id == id);
    }
}
