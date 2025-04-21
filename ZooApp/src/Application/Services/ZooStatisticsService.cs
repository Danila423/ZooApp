using System.Linq;
using ZooApp.Application.Interfaces;
using ZooApp.Domain.Repositories;

namespace ZooApp.Application.Services
{
    public class ZooStatisticsService : IZooStatisticsService
    {
        private readonly IAnimalRepository _animals;
        private readonly IEnclosureRepository _enclosures;

        public ZooStatisticsService(IAnimalRepository animals, IEnclosureRepository enclosures)
        {
            _animals = animals;
            _enclosures = enclosures;
        }

        public int GetTotalAnimals() => _animals.GetAll().Count();
        public int GetFreeEnclosures() => _enclosures.GetAll().Count(e => e.Capacity > e.CurrentCount);
    }
}
