using System;

namespace _04.BorderControl.Exceptions
{
    public class InvalidInputException:Exception
    {
        private const string INVALID_INPUT_EXCEPTION_MESSAGE = "Invalid input!";
        public InvalidInputException():base(INVALID_INPUT_EXCEPTION_MESSAGE)
        {
                
        }
    }
}
