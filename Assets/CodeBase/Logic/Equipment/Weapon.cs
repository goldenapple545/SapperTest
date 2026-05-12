namespace CodeBase.Logic.Equipment
{
    public class Weapon : Item
    {
        public int Ammo { get; private set; }

        public Weapon(string name, int ammo) : base(name)
        {
            Ammo = ammo;
        }

        public void SetAmmo(int ammo)
        {
            Ammo = ammo;
        }
    }
}