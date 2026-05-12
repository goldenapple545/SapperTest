using CodeBase.Logic.Equipment;
using CodeBase.Logic.Player;
using CodeBase.Logic.Settings;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    /// <summary>
    /// Регистрируем ключевые зависимости
    /// </summary>
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private EquipmentSettings equipmentSettings;

        public override void InstallBindings()
        {
            // Настройки
            Container.BindInstance(playerSettings).AsSingle();
            Container.BindInstance(equipmentSettings).AsSingle();

            // Один общий экземпляр экипировки
            Container.BindInterfacesAndSelfTo<Equipment>().AsSingle();

            // Один общий экземпляр игрока
            Container.Bind<IPlayer>().To<Player>().AsSingle();

            // Фабрики для экипировки
            Container.BindFactory<string, int, Weapon, WeaponFactory>();
            Container.BindFactory<string, Parachute, ParachuteFactory>();
            Container.BindFactory<int, RocketPack, RocketPackFactory>();
            
            // Инициализируем игрока
            Container.BindInterfacesTo<PlayerInitializer>().AsSingle();
        }
    }
}