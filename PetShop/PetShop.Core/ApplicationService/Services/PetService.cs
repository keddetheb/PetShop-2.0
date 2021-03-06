﻿using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Pet NewPet(string name, string species, string birthDate, string soldDate, string color, string previousOwner, int price)
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

            List<Pet> SortedList = _petRepo.ReadAll().ToList().OrderBy(x => x.Price).ToList();
            return SortedList;
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

        public Boolean DeletPet(int id)
        {
            return _petRepo.Delete(id);
        }
    }
}
