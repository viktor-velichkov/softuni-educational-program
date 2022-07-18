using System;

namespace WildFarm.Exceptions
{
    class WrongFoodTypeException : Exception
    {
        public WrongFoodTypeException(string message) : base(message)
        {

        }
    }
}
