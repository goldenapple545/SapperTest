using System;
using UnityEngine;

namespace CodeBase
{
    /// <summary>
    /// Точка входа, вешаем на компонент в стартовой сцене
    /// </summary>
    public class GameBootstrap: MonoBehaviour
    {
        public void Start()
        {
            Player player = Player.Instance;
            player.Health = 100;
            player.Lives = 3;
            player.Nickname = "John";
            player.Skills = new string[] { "Skill1", "Skill2", "Skill3" };
            player.Equipment = new Equipment();
            Debug.Log("Здоровье игрока:" + player.Health);
            Debug.Log("Никнейм игрока: " + player.Nickname);
            Equipment equipment = player.Equipment;
            equipment.AddItem(new Weapon("Винтовка", 50));
            equipment.AddItem(new Parachute("Парашют"));
            equipment.AddItem(new RocketPack(3)); // Ракетный ранец с 3 зарядами
        }
    }
}