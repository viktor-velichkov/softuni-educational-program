using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidURLException:Exception
    {
        private const string INVALID_URL_EXCEPTION_MESSAGE = "Invalid URL!";
        public InvalidURLException():base(INVALID_URL_EXCEPTION_MESSAGE)
        {

        }
    }
}
