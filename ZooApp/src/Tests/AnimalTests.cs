using System;
using Xunit;
using ZooApp.Domain.Entities;
using ZooApp.Domain.ValueObjects;

namespace ZooApp.Tests.Domain
{
    public class AnimalTests
    {
        private readonly Animal _animal;
        private readonly Guid _initialEnclosure;

        public AnimalTests()
        {
            _initialEnclosure = Guid.NewGuid();
            _animal = new Animal(
                new Species("Lion"),
                "Leo",
                new DateTime(2020, 1, 1),
                Sex.Male,
                new FoodType("Meat"),
                _initialEnclosure
            );
        }

        [Fact]
        public void NewAnimal_IsHealthy_ByDefault()
        {
            Assert.True(_animal.IsHealthy);
        }

        [Fact]
        public void Heal_MakesAnimalHealthy()
        {
            // Arrange: simulate sick
            typeof(Animal)
                .GetProperty("IsHealthy")
                .SetValue(_animal, false);

            // Act
            _animal.Heal();

            // Assert
            Assert.True(_animal.IsHealthy);
        }

        [Fact]
        public void MoveTo_UpdatesEnclosureId()
        {
            var newEnclosure = Guid.NewGuid();
            _animal.MoveTo(newEnclosure);
            Assert.Equal(newEnclosure, _animal.EnclosureId);
        }

        [Fact]
        public void Feed_DoesNotThrow()
        {
            var ex = Record.Exception(() => _animal.Feed());
            Assert.Null(ex);
        }
    }
}
