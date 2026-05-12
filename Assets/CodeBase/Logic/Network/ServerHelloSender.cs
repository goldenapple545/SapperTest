using CodeBase.Infrastructure.Services.NetworkService;
using Mirror;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.Network
{
    public class ServerHelloSender : MonoBehaviour
    {
        private INetworkMessageSubscriptionService _service;

        [Inject]
        public void Construct(INetworkMessageSubscriptionService service)
        {
            _service = service;
        }

        private void Update()
        {
            if (!NetworkServer.active)
                return;

            if (Input.GetKeyDown(KeyCode.H))
            {
                _service.SendHelloToSubscribedClients("Hello Client!");
            }
        }
    }
}