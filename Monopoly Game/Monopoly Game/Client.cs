using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Xml.Serialization;
using System.IO;

namespace Monopoly_Game
{
    /*
    * Rex Christesnsen: Client.cs version 1.0 3/12/2019
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Methods for connecting to and communicating with a host server.
    * Corrections made for threading, network communication, and serialization/deserialization - Rex 1APR2019
    * Added creation of the Player object to this class, rather than being read from the server - Rex 5Apr19
    * Changed the server IP address to an IP address provided by the user - Rex 5Apr19
    */
    class Client {
        Int32 port = 14242;
        TcpClient client;
        string server;
        Game currentGame;
        Player myPlayer;
        bool inGame;

        public Game CurrentGame { get { return currentGame; } set { currentGame = value; } }

        public Client() {
            //server = "127.0.0.1";
            server = GameEngine.IpAddress;
            inGame = false;
        }

        public void ConnectToServer() {
            Thread newThread = new Thread(Connect);
            newThread.Start();
        }

        private void Connect() {
            client = new TcpClient(server, port);

            Thread readThread = new Thread(() => Read(client));
            readThread.IsBackground = true;
            readThread.Start();
        }

        private void Read(object obj) { // The object parameter shouldn't be needed
            while (true) {
                try {
                    byte[] bytes = new byte[256];
                    string data = null;
                    string fullData = "";

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) > 0) { // This is sending both the player and the game at the same time
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        int x = data.Length;
                        fullData += data;
                        if (!stream.DataAvailable) break;
                    }

                    var receivedObject = DeserializeObject(fullData);

                    if (receivedObject is Game) {
                        currentGame = (Game)receivedObject;
                        // What if I add a player creation here
                        myPlayer = new Player();
                        currentGame.Players.Add(myPlayer);
                        inGame = true;
                        SendMessage(currentGame);
                    }
                    //} else if (receivedObject is Player) {
                    //    myPlayer = (Player)receivedObject;
                    //    if (!inGame) {
                    //        currentGame.Players.Add(myPlayer);
                    //        inGame = true;
                    //        SendMessage(currentGame); // Send back game object with new player added
                    //    }
                    //}

                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SendMessage(Game game) {
            Thread sendThread = new Thread(() => Send(game));
            sendThread.Start();
        }

        private void Send(Game game) {
            string message = null;
            try {
                // Serialize game object to .XML string
                message = SerializeObject(game);
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        // Shamelessly stolen from:
        // https://stackoverflow.com/questions/2434534/serialize-an-object-to-string
        private string SerializeObject<T>(T toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter()) {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        // Shamelessly modified from:
        // https://stackoverflow.com/questions/10518372/how-to-deserialize-xml-to-object
        private object DeserializeObject(string gameText) {
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(Game));
                using (TextReader reader = new StringReader(gameText)) {
                    var result = serializer.Deserialize(reader);

                    result = (Game)result;
                    return result;
                }
            } catch (Exception ex) {
                XmlSerializer serializer = new XmlSerializer(typeof(Player));
                using (TextReader reader = new StringReader(gameText)) {
                    var result = serializer.Deserialize(reader);
                    result = (Player)result;
                    return result;
                }
            }
        }
    }
}
