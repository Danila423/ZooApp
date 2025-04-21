using System;
using System.Collections.Generic;
using ZooApp.Domain.Entities;

namespace ZooApp.Domain.Repositories
{
    public interface IEnclosureRepository
    {
        Enclosure GetById(Guid id);
        IEnumerable<Enclosure> GetAll();
        void Add(Enclosure enclosure);
        void Remove(Guid id);
    }
}
