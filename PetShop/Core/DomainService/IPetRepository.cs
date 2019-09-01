using System.Collections.Generic;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet ReadyById(int id);
        IEnumerable<Pet> ReadAll();
        Pet Updata(Pet petUpdata);
        Pet Delete(int id);

    }
}
