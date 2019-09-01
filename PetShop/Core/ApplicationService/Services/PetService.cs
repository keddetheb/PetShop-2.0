﻿using PetShop.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        public PetService(IPetRepository petService)
        {
            _petRepo = petService;
        }

        public Pet NewPet(string name, string species, string birthDate, string soldDate, string color, string previousOwner, string price)
        {
            var pet = new Pet
            {
                Name = name,
                Species = species,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };

            return pet;
        }

        public Pet CreateAPet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadyById(id);
        }

        public List<Pet> GetAllePets()
        {
            return _petRepo.ReadAll().ToList();
        }

        public Pet UpdadtePet(Pet updadtePet)
        {
            var pet = FindPetById(updadtePet.Id);
            pet.Name = updadtePet.Name;
            pet.Species = updadtePet.Species;
            pet.Birthdate = updadtePet.Birthdate;
            pet.SoldDate = updadtePet.SoldDate;
            pet.Color = updadtePet.Color;
            pet.PreviousOwner = updadtePet.PreviousOwner;
            pet.Price = updadtePet.Price;
            return pet;
        }

        public Pet DeletPet(int id)
        {
            return _petRepo.Delete(id);
        }
    }
}
