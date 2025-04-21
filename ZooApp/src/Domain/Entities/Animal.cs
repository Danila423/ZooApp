using System;
using ZooApp.Domain.ValueObjects;
//using ZooApp.src.Application.ValueObjects;

namespace ZooApp.Domain.Entities
{
    /// <summary>
    /// Животное: вид, кличка, дата рождения, пол, любимая еда, статус (здоров/болен).
    /// Методы: кормить, лечить, переместить в другой вольер.
    /// </summary>
    public class Animal
    {
        public Guid Id { get; private set; }
        public Species Species { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Sex Sex { get; private set; }
        public FoodType FavoriteFood { get; private set; }
        public bool IsHealthy { get; private set; }
        public Guid EnclosureId { get; private set; }

        public Animal(Species species, string name, DateTime birthDate, Sex sex, FoodType favoriteFood, Guid enclosureId)
        {
            Id = Guid.NewGuid();
            Species = species;
            Name = name;
            BirthDate = birthDate;
            Sex = sex;
            FavoriteFood = favoriteFood;
            IsHealthy = true;
            EnclosureId = enclosureId;
        }

        public void Feed()
        {
            // бизнес-логика кормления
        }

        public void Heal() => IsHealthy = true;

        public void MoveTo(Guid newEnclosureId) => EnclosureId = newEnclosureId;
    }
}
