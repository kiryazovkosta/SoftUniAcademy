using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browsing(string site)
        {
            return site.Any(char.IsDigit) ? "Invalid URL!" : $"Browsing: {site}!";
        }

        public string MakeCall(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return "Invalid number!";
            }

            return number.Length == 10 ? $"Calling... {number}" : $"Dialing... {number}";
        }
    }
}
