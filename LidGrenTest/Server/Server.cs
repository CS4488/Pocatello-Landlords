using System;
using System.Collections.Generic;
using Lidgren.Network;

namespace Server
{
    /*
     * Michael Sterner: Server Class 1.0 2/27/19
     * This is a modification of the code sent by email by Rex to the group. This is a server that runs on a console for more effective debugging.
     * Might not really be nessesary, but the adaptation was a bit easier. This can also be found as a class within the Monoploy Game solution.
     * 
     * Please describe changes made here; along with your name, date, and version:
     * M.S. Rex put in Threading into the program class. 2/22/19
     * M.S. I designated this solution for testing in my Eperimental branch... The Monoploy project will act independantly from the Server console just fine.
     * 
     */
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
        //M.S. modified to send messages to all connected servers 
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
            foreach (NetConnection net in server.Connections) { net.Disconnect("Bye"); }
        }
    }
}
