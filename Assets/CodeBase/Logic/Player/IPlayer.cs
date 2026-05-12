namespace CodeBase.Logic.Player
{
    public interface IPlayer
    {
        int Health { get; set; }
        int Lives { get; set; }
        string Nickname { get; set; }
        string[] Skills { get; set; }
        Equipment.Equipment Equipment { get; }

        void SetStats(int health, int lives, string nickname, string[] skills);
    }
}