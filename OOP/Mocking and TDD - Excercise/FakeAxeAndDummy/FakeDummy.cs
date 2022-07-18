using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy
{
    public class FakeDummy : ITarget

    {
        public int Health => 100;

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
