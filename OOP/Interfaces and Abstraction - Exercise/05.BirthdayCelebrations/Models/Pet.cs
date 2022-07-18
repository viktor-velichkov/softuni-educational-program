using _05.BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _05.BirthdayCelebrations.Models
{
    public class Pet : IBeing
    {
        string name;
        string birthdate;
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }
        public string Birthdate
        {
            get { return this.birthdate; }
            set
            {
                this.birthdate = value;
            }
        }
    }
}
