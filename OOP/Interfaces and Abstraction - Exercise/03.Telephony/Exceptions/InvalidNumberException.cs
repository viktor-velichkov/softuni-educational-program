using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony.Exceptions
{
    public class InvalidNumberException:Exception
    {
        private const string INVALID_NUMBER_EXCEPTION_MESSAGE = "Invalid number!";
        public InvalidNumberException():base(INVALID_NUMBER_EXCEPTION_MESSAGE)
        {

        }
    }
}
