using _03.Telephony.Exceptions;
using System.Linq;

namespace _03.Telephony.Models
{
    public class Smartphone : ICaller, IBrowser
    {
        public string Call(string number)
        {
            if (!number.All(x=>char.IsDigit(x)))
            {
                throw new InvalidNumberException();
            }
            return $"Calling... {number}";
        }

        public string Browse(string site)
        {
            if (site.Any(x=>char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }
            return $"Browsing: {site}!";
        }
    }
}
