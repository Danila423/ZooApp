using System;
using ZooApp.Domain.ValueObjects;
//using ZooApp.src.Application.ValueObjects;

namespace ZooApp.Domain.Entities
{
    /// <summary>
    /// Вольер: тип, размер, текущее количество, максимальная вместимость.
    /// Методы: добавить животное, убрать животное, провести уборку.
    /// </summary>
    public class Enclosure
    {
        public Guid Id { get; private set; }
        public EnclosureType Type { get; private set; }
        public double Size { get; private set; }
        public int CurrentCount { get; private set; }
        public int Capacity { get; private set; }

        public Enclosure(EnclosureType type, double size, int capacity)
        {
            Id = Guid.NewGuid();
            Type = type;
            Size = size;
            Capacity = capacity;
            CurrentCount = 0;
        }

        public void AddAnimal()
        {
            if (CurrentCount >= Capacity)
                throw new InvalidOperationException("Вольер полон");
            CurrentCount++;
        }

        public void RemoveAnimal()
        {
            if (CurrentCount <= 0)
                throw new InvalidOperationException("Нет животных для удаления");
            CurrentCount--;
        }

        public void Clean()
        {
            // логика уборки
        }
    }
}
