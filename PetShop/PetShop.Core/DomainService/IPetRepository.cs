using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet ReadyById(int id);
        IEnumerable<Pet> ReadAll();
        Pet Update(Pet petUpdate);
        Pet Delete(int id);

    }
}
