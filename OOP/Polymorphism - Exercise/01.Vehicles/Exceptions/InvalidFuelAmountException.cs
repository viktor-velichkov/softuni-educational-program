using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Exceptions
{
    public class InvalidFuelAmountException : Exception
    {
        public InvalidFuelAmountException(string message) : base(message)
        {
        }

    }
}
