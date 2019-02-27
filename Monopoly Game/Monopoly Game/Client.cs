using Lidgren.Network;
using System;

namespace Monopoly_Game
{
    class Client
    {
        private NetClient client;
        private bool stop;
        public void StartClient()
        {
            var config = new NetPeerConfiguration("game");
            config.AutoFlushSendQueue = false;
            client = new NetClient(config);
            client.Start();

            string ip = "localhost";
            //string ip = "134.50.122.68";
            //string ip = "134.50.156.20";
            int port = 14242;
            client.Connect(ip, port);
        }

        public void SendMessage(string text)
        {
            NetOutgoingMessage message = client.CreateMessage(text);

            client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
            client.FlushSendQueue();
        }

        public void Disconnect()
        {
            client.Disconnect("Bye");
        }

        public void ReadMessages()
        {
            NetIncomingMessage message;
            stop = false;

            while (!stop)
            {
                while ((message = client.ReadMessage()) != null)
                {
                    switch (message.MessageType)
                    {
                        case NetIncomingMessageType.Data:
                            {
                                Console.WriteLine("I got smth!");
                                string data = message.ReadString();
                                Console.WriteLine(data);

                                if (data == "exit")
                                {
                                    stop = true;
                                }

                                break;
                            }
                        case NetIncomingMessageType.DebugMessage:
                            Console.WriteLine(message.ReadString());
                            break;
                        case NetIncomingMessageType.StatusChanged:
                            Console.WriteLine(message.SenderConnection.Status);
                            break;
                        default:
                            Console.WriteLine("Unhandled message type: " + message.MessageType);
                            break;
                    }
                    client.Recycle(message);
                }
            }

            Console.WriteLine("Shutdown package \"exit\" received. Press any key to finish shutdown");
            Console.ReadKey();
        }
    }
}
