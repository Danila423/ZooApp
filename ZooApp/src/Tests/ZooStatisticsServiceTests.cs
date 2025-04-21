using Xunit;
using ZooApp.Application.Services;
using ZooApp.Infrastructure.InMemory;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;

namespace ZooApp.Tests.Application
{
    public class ZooStatisticsServiceTests
    {
        [Fact]
        public void GetTotalAnimals_ReturnsCorrectCount()
        {
            var animals = new AnimalRepository();
            var enclosures = new EnclosureRepository();
            var service = new ZooStatisticsService(animals, enclosures);

            animals.Add(new Animal(new Species("Wolf"), "Wally", System.DateTime.Today, Sex.Male, new FoodType("Meat"), System.Guid.NewGuid()));
            animals.Add(new Animal(new Species("Wolf"), "Wilma", System.DateTime.Today, Sex.Female, new FoodType("Meat"), System.Guid.NewGuid()));

            Assert.Equal(2, service.GetTotalAnimals());
        }

        [Fact]
        public void GetFreeEnclosures_ReturnsCountOfNotFull()
        {
            var animals = new AnimalRepository();
            var enclosures = new EnclosureRepository();
            var service = new ZooStatisticsService(animals, enclosures);

            var e1 = new Enclosure(EnclosureType.Herbivore, 100, 2);
            var e2 = new Enclosure(EnclosureType.Herbivore, 100, 1);
            enclosures.Add(e1);
            enclosures.Add(e2);

            e2.AddAnimal(); // e2 now full

            Assert.Equal(1, service.GetFreeEnclosures());
        }
    }
}
