using System;
using System.Collections.Generic;
using Lidgren.Network;

namespace Server
{
    class Server
    {
        private NetServer server;
        private List<NetPeer> clients;

        public void StartServer()
        {
            var config = new NetPeerConfiguration("game") { Port = 14242 };
            server = new NetServer(config);
            server.Start();

            if (server.Status == NetPeerStatus.Running)
            {
                Console.WriteLine("Server is running on port " + config.Port);
            }
            else
            {
                Console.WriteLine("Server not started...");
            }
            clients = new List<NetPeer>();
        }

        public void ReadMessages()
        {
            NetIncomingMessage message;
            var stop = false;

            while (!stop)
            {
                while ((message = server.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            {
                                Console.WriteLine("Data from: {0}", message.SenderConnection.Peer.Configuration.LocalAddress);
                                var data = message.ReadString();
                                Console.WriteLine(data);
                                if (data == "exit")
                                {
                                    stop = true;
                                }
                                SendMessage(data);
                                break;
                            }
                        case NetIncomingMessageType.DebugMessage:
                            Console.WriteLine(message.ReadString());
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            Console.WriteLine(message.SenderConnection.Status);
                            if (message.SenderConnection.Status == NetConnectionStatus.Connected)
                            {
                                clients.Add(message.SenderConnection.Peer);
                                Console.WriteLine("{0} has connected.", message.SenderConnection.Peer.Configuration.LocalAddress);
                            }
                            if (message.SenderConnection.Status == NetConnectionStatus.Disconnected)
                            {
                                clients.Remove(message.SenderConnection.Peer);
                                Console.WriteLine("{0} has disconnected.", message.SenderConnection.Peer.Configuration.LocalAddress);
                            }
                            break;
                        default:
                            Console.WriteLine("Unhandled message type: {message.MessageType}");
                            break;
                    }
                    server.Recycle(message);
                }
            }

            Console.WriteLine("Shutdown package \"exit\" received. Press any key to finish shutdown");
            Console.ReadKey();
        }

        public void SendMessage(string text)
        {
            if (server.Connections.Count != 0)
            {
                foreach (NetConnection net in server.Connections)
                {
                    NetOutgoingMessage message = server.CreateMessage(text);
                    server.SendMessage(message, net, NetDeliveryMethod.ReliableOrdered);
                    server.FlushSendQueue();
                }
            }
        }

        public void Disconnect()
        {
            NetConnection net = server.Connections[0];
            net.Disconnect("Bye");
        }
    }
}
