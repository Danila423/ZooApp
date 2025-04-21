using System;
using Xunit;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;

namespace ZooApp.Tests.Domain
{
    public class EnclosureTests
    {
        [Fact]
        public void NewEnclosure_HasZeroAnimals()
        {
            var enc = new Enclosure(EnclosureType.Aviary, 50, 5);
            Assert.Equal(0, enc.CurrentCount);
        }

        [Fact]
        public void AddAnimal_IncrementsCount()
        {
            var enc = new Enclosure(EnclosureType.Herbivore, 100, 2);
            enc.AddAnimal();
            Assert.Equal(1, enc.CurrentCount);
        }

        [Fact]
        public void AddAnimal_WhenFull_Throws()
        {
            var enc = new Enclosure(EnclosureType.Herbivore, 100, 1);
            enc.AddAnimal();
            Assert.Throws<InvalidOperationException>(() => enc.AddAnimal());
        }

        [Fact]
        public void RemoveAnimal_DecrementsCount()
        {
            var enc = new Enclosure(EnclosureType.Carnivore, 80, 2);
            enc.AddAnimal();
            enc.RemoveAnimal();
            Assert.Equal(0, enc.CurrentCount);
        }

        [Fact]
        public void RemoveAnimal_WhenEmpty_Throws()
        {
            var enc = new Enclosure(EnclosureType.Carnivore, 80, 2);
            Assert.Throws<InvalidOperationException>(() => enc.RemoveAnimal());
        }

        [Fact]
        public void Clean_DoesNotThrow()
        {
            var enc = new Enclosure(EnclosureType.Aquarium, 30, 5);
            var ex = Record.Exception(() => enc.Clean());
            Assert.Null(ex);
        }
    }
}
