using PetShop.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShope.Infrastructure.Static.Data;
using PetShop.Infrastructure.Static.Data;
using System.Linq;

namespace PetShop
{
    public class MirrorImage : IMirrorImage
    {
        readonly IPetService _petService;

        public MirrorImage(IPetService petService)
        {
            _petService = petService;
        }
        public void StartUI()
        {
            String[] menuPets =
        {
            "List Off All Pets",
            "List Off Five Cheapest Pets",
            "List By Type",
            "Add a Pet",
            "Delete a Pet",
            "Edit a Pet",
            "Exit"
        };

            var selection = ShowMenu(menuPets);

            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllePets();
                        ListPets(pets);
                        break;
                    case 2:
                        pets = _petService.GetAllePets();
                        ListFivePets(pets);
                        break;
                    case 3:
                        var species = AskQuestion("Species: ");
                        pets = _petService.GetAllePets();
                        ListTypeOfPets(pets, species);
                        break;
                    case 4:
                        var name = AskQuestion("Name: ");
                        species = AskQuestion("Species: ");
                        var birthdate = AskQuestion("Birthdate: ");
                        var soldDate = AskQuestion("SoldDate: ");
                        var color = AskQuestion("Color: ");
                        var previousOwner = AskQuestion("PreviousOwner: ");
                        var price = AskQuestion("price: ");
                        var pet = _petService.NewPet(name, species, birthdate, soldDate, color, previousOwner, int.Parse(price));
                        _petService.CreateAPet(pet);
                        break;
                    case 5:
                        var idForDelete = PrintFindAPetsId();
                        _petService.DeletPet(idForDelete);
                        break;
                    case 6:
                        var idForEdit = PrintFindAPetsId();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var newSpecies = AskQuestion("Species: ");
                        var newBirthdate = AskQuestion("Birthdate: ");
                        var newSoldDate = AskQuestion("SoldDate: ");
                        var newColor = AskQuestion("Color: ");
                        var newPreviousOwner = AskQuestion("PreviousOwner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdadtePet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Species = newSpecies,
                            Birthdate = newBirthdate,
                            SoldDate = newSoldDate,
                            Color = newColor,
                            PreviousOwner = newColor,
                            Price = int.Parse(newPrice)
                        });
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuPets);
            }
            Console.WriteLine("Come again");
            Console.ReadLine();
        }
        int PrintFindAPetsId()
        {
            Console.WriteLine("Id please: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("a number");
            }
            return id;
        }
        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nThe list of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id}{"\n"}Name:{pet.Name}{"\n"}Species:{pet.Color} + {pet.Species}{"\n"}Birthdate:{pet.Birthdate}{"\n"}SoldDate:{pet.SoldDate}{"\n"}Price:{pet.Price}{"\n"}PreciousOwner:{pet.PreviousOwner}{"\n"}");
            }
            Console.WriteLine("\n");

        }

        void ListFivePets(List<Pet> pets)
        {
            var firstFiveItems = pets.Take(5);
            Console.WriteLine("\nThe list of Pets");
            foreach (var pet in firstFiveItems)
            {
                Console.WriteLine($"Id: {pet.Id}{"\n"}Name:{pet.Name}{"\n"}Species:{pet.Color} + {pet.Species}{"\n"}Birthdate:{pet.Birthdate}{"\n"}SoldDate:{pet.SoldDate}{"\n"}Price:{pet.Price}{"\n"}PreciousOwner:{pet.PreviousOwner}{"\n"}");
            }
            Console.WriteLine("\n");

        }

        void ListTypeOfPets(List<Pet> pets, String species)
        {
            List<Pet> Result = new List<Pet>();
            foreach (var pet in pets)
            {
                if(pet.Species==species)
                {
                    Result.Add(pet);
                }
            }
            Console.WriteLine("\nThe list of " + species + "s");
            foreach (var pet in Result)
            {
                Console.WriteLine($"Id: {pet.Id}{"\n"}Name:{pet.Name}{"\n"}Species:{pet.Color} + {pet.Species}{"\n"}Birthdate:{pet.Birthdate}{"\n"}SoldDate:{pet.SoldDate}{"\n"}Price:{pet.Price}{"\n"}PreciousOwner:{pet.PreviousOwner}{"\n"}");
            }
            Console.WriteLine("\n");

        }

        int ShowMenu(string[] menuPets)
        {
            Console.WriteLine("welcome to the shop:\n");

            for (int i = 0; i < menuPets.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuPets[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 7)
            {
                Console.WriteLine("use a number between 1-7");
            }

            return selection;
        }

    }
}
