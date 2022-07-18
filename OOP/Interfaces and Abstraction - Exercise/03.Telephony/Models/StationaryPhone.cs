using _03.Telephony.Exceptions;
using System.Linq;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICaller
    {
        public string Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumberException();
            }
            return $"Dialing... {number}";
        }
    }
}
