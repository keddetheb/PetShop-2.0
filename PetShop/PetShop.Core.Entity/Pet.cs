using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Birthdate { get; set; }

        public string SoldDate { get; set; }

        public string Color { get; set; }

        public string PreviousOwner { get; set; }

        public int Price { get; set; }

    }
}
