using CreateLogger.Models.Contracts;

namespace CreateLogger.Models
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
