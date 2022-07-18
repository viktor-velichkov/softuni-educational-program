using System;

namespace _05.BirthdayCelebrations.Exceptions
{
    public class InvalidInputException:Exception
    {
        private const string INVALID_INPUT_EXCEPTION_MESSAGE = "Invalid input!";
        public InvalidInputException():base(INVALID_INPUT_EXCEPTION_MESSAGE)
        {
                
        }
    }
}
