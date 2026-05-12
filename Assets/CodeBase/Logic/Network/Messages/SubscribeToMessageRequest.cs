using Mirror;

namespace CodeBase.Logic.Network.Messages
{
    public struct SubscribeToMessageRequest : NetworkMessage
    {
        public string MessageType;
    }
}