using System;

namespace ZooApp.Application.Interfaces
{
    public interface IAnimalTransferService
    {
        void Transfer(Guid animalId, Guid toEnclosureId);
    }
}
