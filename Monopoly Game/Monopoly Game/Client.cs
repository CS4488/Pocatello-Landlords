using Lidgren.Network;
using System;

namespace Monopoly_Game
{
    class Client
    {
        private NetClient client;
        private bool stop;
        private static string[] parseList;
        private Game clientGame;
        public string[] ParseList { get { return parseList; } }

        public void StartClient(Game game)
        {
            var config = new NetPeerConfiguration("game");
            config.AutoFlushSendQueue = false;
            client = new NetClient(config);
            client.Start();
            clientGame = game;
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
            stop = true;
            client.Disconnect("Bye");
        }

        public void parseGameData()
        {
            if (parseList[0][0] == 'p')
            {
                Space spaceParsed = clientGame.GameBoard.Spaces[Int16.Parse(parseList[2])];
                if (spaceParsed is Property)
                {
                    Property propertyClicked = (Property)spaceParsed;
                    if (propertyClicked.Owner == -1)
                    {
                        propertyClicked.Owner = clientGame.CurrentPlayer.PlayerID;
                        clientGame.makeNextPlayersTurn();
                    }
                }
            }
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
                                parseList = message.ReadString().Split(' ');

                                if (parseList[0] == "exit")
                                {
                                    stop = true;
                                }
                                parseGameData();
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
        }
    }
}
