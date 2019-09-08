using PetShop.Core.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core.ApplicationService;
using PetShop.Infrastructure.Static.Data;
using System.Linq;

namespace PetShope.Infrastructure.Static.Data
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
            if (FakeDB.Pets.Count >= 1) return;
            var pet1 = new Pet()
            {
                Id = FakeDB.Id++,
                Name = "King",
                Species = "Dog",
                Birthdate = "21-07-2000",
                SoldDate = "12-05-2006",
                Color = "Black",
                PreviousOwner = "Karl Jensen",
                Price = "7800",

            };
            FakeDB.Pets.Add(pet1);

            var pet2 = new Pet()
            {
                Id = FakeDB.Id++,
                Name = "Misha",
                Species = "Cat",
                Birthdate = "09-05-2016",
                SoldDate = "21-12-2018",
                Color = "Grey",
                PreviousOwner = "Ruth Wilson",
                Price = "2500",

            };
            FakeDB.Pets.Add(pet2);

            var pet3 = new Pet()
            {
                Id = FakeDB.Id++,
                Name = "Perry",
                Species = "Platapus",
                Birthdate = "25-01-208",
                SoldDate = "02-10-2017",
                Color = "Blue",
                PreviousOwner = "Phineas and Ferb",
                Price = "250000",

            };
            FakeDB.Pets.Add(pet3);
        }
        static int id = 1;

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            FakeDB.Pets.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.Pets;
        }


        public Pet ReadyById(int id)
        {
            return FakeDB.Pets.Select(c => new Pet()
            {
                Id = c.Id,
                Name = c.Name,
                Species = c.Species,
                Color = c.Color,
                Birthdate = c.Birthdate,
                Price = c.Price,
                SoldDate = c.SoldDate,
                PreviousOwner = c.PreviousOwner,
            }).
            FirstOrDefault(c => c.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            var PetFromDB = this.ReadyById(petUpdate.Id);
            if (PetFromDB != null)
            {
                PetFromDB.Name = petUpdate.Name;
                PetFromDB.Species = petUpdate.Species;
                PetFromDB.SoldDate = petUpdate.SoldDate;
                PetFromDB.Birthdate = petUpdate.Birthdate;
                PetFromDB.Price = petUpdate.Price;
                PetFromDB.PreviousOwner = petUpdate.PreviousOwner;
                return PetFromDB;
            }
            return null;
        }

        public Pet Delete(int id)
        {
            var petFound = ReadyById(id);
            //if (petFound == null) return null;

            FakeDB.Pets.Remove(petFound);
            return petFound;

        }

    }
}
