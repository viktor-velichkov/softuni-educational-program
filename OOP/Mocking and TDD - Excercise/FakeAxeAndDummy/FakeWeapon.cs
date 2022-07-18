using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 50;

        public int DurabilityPoints => 50;

        public void Attack(ITarget target)
        {
            
        }
    }
}
