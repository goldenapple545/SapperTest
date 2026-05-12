using CodeBase.Infrastructure.Services.NetworkService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    /// <summary>
    /// Регистрируем сетевые обработчики Mirror при старте сцены.
    /// </summary>
    public class NetworkMessagesBootstrap : IInitializable
    {
        private readonly INetworkMessageSubscriptionService _service;

        public NetworkMessagesBootstrap(INetworkMessageSubscriptionService service)
        {
            _service = service;
        }

        public void Initialize()
        {
            _service.RegisterServerHandlers();
            _service.RegisterClientHandlers();

            Debug.Log("NetworkMessagesBootstrap initialized");
        }
    }
}