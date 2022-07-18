using System;

namespace Raiding.Exceptions
{
    public class InvalidHeroTypeException : Exception
    {
        public InvalidHeroTypeException(string message) : base(message)
        {
        }
    }
}
