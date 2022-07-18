using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Exceptions
{
    public class NotEnoughFuelException : Exception
    {
        public NotEnoughFuelException(string message) : base(message)
        {
        }
    }
}
