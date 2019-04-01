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

namespace Monopoly_Game {
    /*
    * Rex Christesnsen: Client.cs version 1.0 3/12/2019
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Methods for connecting to and communicating with a host server.
    */
    class Client {
        Int32 port = 14242;
        TcpClient client;
        string server;
        Game currentGame;
        Player myPlayer;
        bool inGame;

        public Game CurrentGame { get{ return currentGame; } }

        public Client() {
            server = "127.0.0.1";
            inGame = false;
        }

        public void ConnectToServer() {
            Thread newThread = new Thread(Connect);
            newThread.Start();
        }

        private void Connect() { // Changed from void to Task and added async
            client = new TcpClient(server, port);
            //ThreadPool.QueueUserWorkItem(Read, client); // ***** Do I want to do this as a pool? or just create a new thread?

            Read(client);

            Thread readThread = new Thread(() => Read(client));
            readThread.IsBackground = true;
            readThread.Start();
        }

        private void Read(object obj) { // The object parameter shouldn't be needed
            try {
                byte[] bytes = new byte[256]; // This buffer is not long enough
                string data = null;
                string fullData = "";

                NetworkStream stream = client.GetStream();

                int i;

                while (stream.DataAvailable && (i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    int x = data.Length;
                    fullData += data;
                }
                // **** Nothing below this line appears to be firing. 

                var receivedObject = DeserializeObject(fullData);

                if (receivedObject is Game) {
                    currentGame = (Game)receivedObject;
                    // This shouldn't be null;
                    currentGame.MyPlayer = myPlayer;
                    if (!inGame) {
                        currentGame.Players.Add(myPlayer);
                        inGame = true;
                        SendMessage(currentGame); // ****** This is sending back the game object with this player now added to the Players list
                    }
                } else if (receivedObject is Player) {
                    myPlayer = (Player)receivedObject;
                }
                // Return the game object to the caller

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
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

                //stream.Close();
                //client.Close();
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

        // Shamelessly stolen from:
        // https://stackoverflow.com/questions/10518372/how-to-deserialize-xml-to-object
        private object DeserializeObject(string gameText) {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (TextReader reader = new StringReader(gameText)) {
                var result = serializer.Deserialize(reader); // This was a game object with the deserializer cast to Game as well
                // ????
                if (result is Game) {
                    result = (Game)result;
                } else if (result is Player) {
                    result = (Player)result;
                }
                return result;
            }
        }
    }
}
