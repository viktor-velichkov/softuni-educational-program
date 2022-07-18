using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Contracts
{
    public interface IBeing
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
