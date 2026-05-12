using CodeBase.Infrastructure.Services.NetworkService;
using CodeBase.Logic.Network;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class NetworkMessagesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<INetworkMessageSubscriptionService>()
                .To<MirrorNetworkMessageSubscriptionService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<NetworkMessagesBootstrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}