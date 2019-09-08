using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Static.Data
{
    public static class FakeDB
    {
        public static int Id = 1;
        public static readonly List<Pet> Pets = new List<Pet>();
    }
}
