using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lidgren.Network;
namespace Monopoly_Game
{
    class Server
    {
        private Game game;
        private static NetServer server;
        public Server(Game inputGame)
        {
            game = inputGame;
            NetPeerConfiguration config = new NetPeerConfiguration("chat");
            config.MaximumConnections = 100;
            config.Port = 14242;
            server = new NetServer(config);
            System.Windows.Application.Current.Activated += new EventHandler(RunServer);
        }
        public void StartServer()
        {
            server.Start();
        }
        public void Shutdown()
        {
            server.Shutdown("Requested by user");
        }
        private void RunServer(object sender, EventArgs e)
        {
            while (game.gameState == GameStates.Running)
            {
                NetIncomingMessage im;
                while ((im = server.ReadMessage()) != null)
                {
                    // handle incoming message
                    switch (im.MessageType)
                    {
                        case NetIncomingMessageType.DebugMessage:
                        case NetIncomingMessageType.ErrorMessage:
                        case NetIncomingMessageType.WarningMessage:
                        case NetIncomingMessageType.VerboseDebugMessage:
                            string text = im.ReadString();
                            System.Windows.MessageBox.Show(text);
                            break;

                        case NetIncomingMessageType.StatusChanged:
                            NetConnectionStatus status = (NetConnectionStatus)im.ReadByte();

                            string reason = im.ReadString();
                            System.Windows.MessageBox.Show(NetUtility.ToHexString(im.SenderConnection.RemoteUniqueIdentifier) + " " + status + ": " + reason);

                            if (status == NetConnectionStatus.Connected)
                                System.Windows.MessageBox.Show("Remote hail: " + im.SenderConnection.RemoteHailMessage.ReadString());

                            //UpdateConnectionsList();
                            break;
                        case NetIncomingMessageType.Data:
                            // incoming chat message from a client
                            string chat = im.ReadString();

                            System.Windows.MessageBox.Show("Broadcasting '" + chat + "'");

                            // broadcast this to all connections, except sender
                            List<NetConnection> all = server.Connections; // get copy
                            all.Remove(im.SenderConnection);

                            if (all.Count > 0)
                            {
                                NetOutgoingMessage om = server.CreateMessage();
                                om.Write(NetUtility.ToHexString(im.SenderConnection.RemoteUniqueIdentifier) + " said: " + chat);
                                server.SendMessage(om, all, NetDeliveryMethod.ReliableOrdered, 0);
                            }
                            break;
                        default:
                            System.Windows.MessageBox.Show("Unhandled type: " + im.MessageType + " " + im.LengthBytes + " bytes " + im.DeliveryMethod + "|" + im.SequenceChannel);
                            break;
                    }
                    server.Recycle(im);
                }
                Thread.Sleep(1);
            }
        }
    }
}
