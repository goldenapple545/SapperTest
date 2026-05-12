namespace CodeBase.Logic.Equipment
{
    public class RocketPack : Item
    {
        public int Charges { get; private set; }

        public RocketPack(int charges) : base("RocketPack")
        {
            Charges = charges;
        }

        public void SetCharges(int charges)
        {
            Charges = charges;
        }
    }
}