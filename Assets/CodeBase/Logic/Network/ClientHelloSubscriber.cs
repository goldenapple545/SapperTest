using CodeBase.Infrastructure.Services.NetworkService;
using Mirror;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Network
{
    /// <summary>
    /// После подключения клиент отправляет на сервер подписку на HelloMessage.
    /// </summary>
    public class ClientHelloSubscriber : MonoBehaviour
    {
        private INetworkMessageSubscriptionService _service;
        private bool _subscriptionSent;

        [Inject]
        public void Construct(INetworkMessageSubscriptionService service)
        {
            _service = service;
        }

        private void Update()
        {
            if (_subscriptionSent)
                return;

            if (NetworkClient.isConnected)
            {
                _service.SubscribeClientToHello();
                _subscriptionSent = true;
            }
        }
    }
}