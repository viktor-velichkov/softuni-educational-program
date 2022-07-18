using System;

namespace _01.Vehicles.Exceptions
{
    public class OverfilledTankException : Exception
    {
        public OverfilledTankException(string message) : base(message)
        {
        }
    }
}
