using CodeBase.Logic.Equipment;
using CodeBase.Logic.Settings;
using Zenject;

namespace CodeBase.Logic.Player
{
    /// <summary>
    /// Инициализируем игрока стартовыми параметрами из ProjectContext
    /// </summary>
    public class PlayerInitializer : IInitializable
    {
        private readonly IPlayer _player;
        private readonly PlayerSettings _playerSettings;
        private readonly EquipmentSettings _equipmentSettings;
        private readonly WeaponFactory _weaponFactory;
        private readonly ParachuteFactory _parachuteFactory;
        private readonly RocketPackFactory _rocketPackFactory;

        public PlayerInitializer(
            IPlayer player,
            PlayerSettings playerSettings,
            EquipmentSettings equipmentSettings,
            WeaponFactory weaponFactory,
            ParachuteFactory parachuteFactory,
            RocketPackFactory rocketPackFactory)
        {
            _player = player;
            _playerSettings = playerSettings;
            _equipmentSettings = equipmentSettings;
            _weaponFactory = weaponFactory;
            _parachuteFactory = parachuteFactory;
            _rocketPackFactory = rocketPackFactory;
        }

        public void Initialize()
        {
            _player.SetStats(
                _playerSettings.Health,
                _playerSettings.Lives,
                _playerSettings.Nickname,
                _playerSettings.Skills);

            _player.Equipment.AddItem(
                _weaponFactory.Create(
                    _equipmentSettings.WeaponName,
                    _equipmentSettings.WeaponAmmo));

            _player.Equipment.AddItem(
                _parachuteFactory.Create(
                    _equipmentSettings.ParachuteName));

            _player.Equipment.AddItem(
                _rocketPackFactory.Create(
                    _equipmentSettings.RocketPackCharges));
        }
    }
}