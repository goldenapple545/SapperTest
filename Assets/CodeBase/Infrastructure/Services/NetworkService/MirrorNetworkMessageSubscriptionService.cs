using System.Collections.Generic;
using CodeBase.Logic.Network.Messages;
using Mirror;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.NetworkService
{
    /// <summary>
    /// Сервис подписок на сетевые сообщения
    /// Сервер хранит список подписок по connectionId и отправляет сообщения
    /// только тем клиентам, которые явно подписались на конкретный тип.
    /// </summary>
    public class MirrorNetworkMessageSubscriptionService : INetworkMessageSubscriptionService
    {
        private const string HelloMessageType = nameof(HelloMessage);

        private readonly Dictionary<int, HashSet<string>> _subscriptions = new();

        public void RegisterServerHandlers()
        {
            NetworkServer.RegisterHandler<SubscribeToMessageRequest>(OnSubscribeRequestReceived, false);
        }

        public void RegisterClientHandlers()
        {
            NetworkClient.RegisterHandler<HelloMessage>(OnHelloMessageReceived, false);
        }

        public void SubscribeClientToHello()
        {
            if (!NetworkClient.isConnected)
            {
                Debug.LogWarning("Клиент еще не подключен к серверу, подписка невозможна.");
                return;
            }

            var request = new SubscribeToMessageRequest
            {
                MessageType = HelloMessageType
            };

            NetworkClient.Send(request);
            Debug.Log("Клиент отправил запрос подписки на HelloMessage");
        }

        public void SendHelloToSubscribedClients(string text)
        {
            if (!NetworkServer.active)
            {
                Debug.LogWarning("Сервер не запущен, отправка невозможна.");
                return;
            }

            foreach (NetworkConnectionToClient conn in NetworkServer.connections.Values)
            {
                if (conn == null)
                    continue;

                if (IsSubscribed(conn.connectionId, HelloMessageType))
                {
                    conn.Send(new HelloMessage
                    {
                        Text = text
                    });

                    Debug.Log($"Сервер отправил HelloMessage клиенту {conn.connectionId}");
                }
            }
        }

        public void SendHelloToClient(NetworkConnectionToClient connection, string text)
        {
            if (connection == null)
            {
                Debug.LogWarning("Connection is null");
                return;
            }

            if (!IsSubscribed(connection.connectionId, HelloMessageType))
            {
                Debug.Log($"Клиент {connection.connectionId} не подписан на HelloMessage, отправка пропущена.");
                return;
            }

            connection.Send(new HelloMessage
            {
                Text = text
            });

            Debug.Log($"Сервер отправил HelloMessage клиенту {connection.connectionId}");
        }

        public bool IsSubscribed(int connectionId, string messageType)
        {
            return _subscriptions.TryGetValue(connectionId, out var messageTypes)
                   && messageTypes.Contains(messageType);
        }

        private void OnSubscribeRequestReceived(NetworkConnectionToClient conn, SubscribeToMessageRequest msg)
        {
            if (!_subscriptions.TryGetValue(conn.connectionId, out var messageTypes))
            {
                messageTypes = new HashSet<string>();
                _subscriptions[conn.connectionId] = messageTypes;
            }

            messageTypes.Add(msg.MessageType);

            Debug.Log($"Сервер получил подписку от клиента {conn.connectionId} на {msg.MessageType}");

            if (msg.MessageType == HelloMessageType)
            {
                SendHelloToClient(conn, "Hello Client!");
            }
        }

        private void OnHelloMessageReceived(HelloMessage msg)
        {
            Debug.Log($"Клиент получил HelloMessage: {msg.Text}");
        }
    }
}