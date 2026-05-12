using System;

namespace CodeBase.Logic.Settings
{
    [Serializable]
    public class PlayerSettings
    {
        public int Health = 100;
        public int Lives = 3;
        public string Nickname = "John";
        public string[] Skills = { "Skill1", "Skill2", "Skill3" };
    }
}