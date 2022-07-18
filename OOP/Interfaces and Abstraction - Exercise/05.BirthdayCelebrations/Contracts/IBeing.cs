using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Contracts
{
    public interface IBeing
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
