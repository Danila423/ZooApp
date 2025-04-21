using System;
using System.Collections.Generic;
using ZooApp.Domain.Entities;

namespace ZooApp.Domain.Repositories
{
    public interface IAnimalRepository
    {
        Animal GetById(Guid id);
        IEnumerable<Animal> GetAll();
        void Add(Animal animal);
        void Remove(Guid id);
    }
}
