using CodeBase.Logic.Equipment;
using CodeBase.Logic.Player;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class MainBootstrap: MonoBehaviour
    {
        private IPlayer _player;

        [Inject]
        public void Construct(IPlayer player)
        {
            _player = player;
        }

        private void Start()
        {
            Debug.Log("Здоровье игрока до старта сцены: " + _player.Health);
            Debug.Log("Никнейм игрока: " + _player.Nickname);

            var weapon = _player.Equipment.GetItem<Weapon>();
            var rocketPack = _player.Equipment.GetItem<RocketPack>();

            if (weapon != null)
            {
                Debug.Log("Оружие: " + weapon.Name + ", патроны: " + weapon.Ammo);
                weapon.SetAmmo(120);
                Debug.Log("Оружие: " + weapon.Name + ", патроны после изменения: " + weapon.Ammo);
            }

            if (rocketPack != null)
            {
                Debug.Log("Заряды ранца: " + rocketPack.Charges);
                rocketPack.SetCharges(5);
                Debug.Log("Заряды ранца после изменения: " + rocketPack.Charges);
            }

            _player.Health = 80;
            Debug.Log("Здоровье игрока после старта сцены: " + _player.Health);
        }
    }
}