namespace CodeBase
{
    public class RocketPack : Item 
    { 
        private int _charges;
        public RocketPack(int charges) : base("RocketPack")
        { 
            _charges = charges;
        }
    }
}