﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPet(string name, string species, string birthDate, string soldDate, string color, string previousOwner, string price);
        Pet CreateAPet(Pet pet);
        Pet FindPetById(int id);
        List<Pet> GetAllePets();
        Pet UpdadtePet(Pet updadtePet);
        Pet DeletPet(int id);
    }
}
