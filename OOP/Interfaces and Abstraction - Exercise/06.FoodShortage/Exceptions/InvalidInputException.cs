using System;

namespace _06.FoodShortage.Exceptions
{
    public class InvalidInputException:Exception
    {
        private const string INVALID_INPUT_EXCEPTION_MESSAGE = "Invalid input!";
        public InvalidInputException():base(INVALID_INPUT_EXCEPTION_MESSAGE)
        {
                
        }
    }
}
