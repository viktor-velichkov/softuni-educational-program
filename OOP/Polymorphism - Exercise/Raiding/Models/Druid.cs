namespace Raiding.Models
{
    public class Druid : Healer
    {
        private const int DEFAULT_DRUID_POWER = 80;
        public Druid(string name) : base(name, DEFAULT_DRUID_POWER)
        {

        }
    }
}
