namespace CodeBase.Logic.Player
{
    /// <summary>
    /// Класс игрока, сейчас используется как хранилище данных
    /// </summary>
    public class Player : IPlayer
    {
        public int Health { get; set; }
        public int Lives { get; set; }
        public string Nickname { get; set; }
        public string[] Skills { get; set; }

        /// <summary>
        /// Экипировка игрока внедряется через конструктор.
        /// </summary>
        public Equipment.Equipment Equipment { get; }
        
        public Player(Equipment.Equipment equipment)
        {
            Equipment = equipment;
        }

        public void SetStats(int health, int lives, string nickname, string[] skills)
        {
            Health = health;
            Lives = lives;
            Nickname = nickname;
            Skills = skills;
        }
    }
}