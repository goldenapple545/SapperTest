using Mirror;

namespace CodeBase.Infrastructure.Services.NetworkService
{
    public interface INetworkMessageSubscriptionService
    {
        void RegisterServerHandlers();
        void RegisterClientHandlers();

        void SubscribeClientToHello();
        void SendHelloToSubscribedClients(string text);
        void SendHelloToClient(NetworkConnectionToClient connection, string text);

        bool IsSubscribed(int connectionId, string messageType);
    }
}