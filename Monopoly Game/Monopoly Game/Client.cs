using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lidgren.Network;
namespace Monopoly_Game
{
    class Client : Player
    {
        private static NetClient client;
        private Property[] board;
        private static string[] parseList;
        public Client()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("chat");
            client = new NetClient(config);
            client.RegisterReceivedCallback(new SendOrPostCallback(GotMessage));
        }
        public static void GotMessage(object peer)
        {
            NetIncomingMessage im;
            while ((im = client.ReadMessage()) != null)
            {
                // handle incoming message
                switch (im.MessageType)
                {
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.ErrorMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.VerboseDebugMessage:
                    case NetIncomingMessageType.StatusChanged:
                    case NetIncomingMessageType.Data:
                        parseList = im.ReadString().Split(' ');
                        //Output(chat);
                        break;
                    default:
                        //Output("Unhandled type: " + im.MessageType + " " + im.LengthBytes + " bytes");
                        break;
                }
                client.Recycle(im);
            }
        }
        public override bool takeTurn(int spaceIndex, Game game)
        {
            bool validTurn = false;
            int moveIndex = this.getMove(game.GameBoard);
            if (moveIndex == -1)
            {
                return validTurn;
            }
            Property toTake = (Property)game.GameBoard.Spaces[moveIndex];
            toTake.Owner = game.CurrentPlayer.PlayerID;
            validTurn = true;
            return validTurn;
        }
        private int getMove(Board inputBoard)
        {
            board = inputBoard.Spaces.Cast<Property>().ToArray();
            int moveToTry = 0;
            Int32.TryParse(parseList[0], out moveToTry);
            if (moveToTry >= 0 && moveToTry <= 8)
                return moveToTry;
            return -1;
        }
        public void Connect(string host, int port)
        {
            client.Start();
            NetOutgoingMessage hail = client.CreateMessage("This is the hail message");
            client.Connect(host, port, hail);
        }
        public static void Send(string text)
        {
            NetOutgoingMessage om = client.CreateMessage(text);
            client.SendMessage(om, NetDeliveryMethod.ReliableOrdered);
            client.FlushSendQueue();
        }
        public static void Disconnect() { client.Disconnect("Requested by user"); }
        public void Shutdown() { client.Shutdown("Requested by user"); }
    }
}
