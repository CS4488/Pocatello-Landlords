using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.IO;
using System.Windows;

namespace Monopoly_Game {
    /*
    * Rex Christesnsen: Server.cs version 1.0 3/12/2019
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Methods for connecting to and communicating with multiple clients.
    * Corrections made for threading, network communication, and serialization/deserialization - Rex 1APR2019
    */
    class Server {
        TcpListener server;
        Int32 port;
        IPAddress localHost;
        byte[] bytes;
        string data;
        List<TcpClient> clients;
        Game currentGame;
        Player myPlayer;
        string gameString;

        public Game CurrentGame { get { return currentGame; } set { currentGame = value; } }
        public Player MyPlayer { get { return myPlayer; } set { myPlayer = value; } }
        public List<TcpClient> Clients { get { return clients; } }

        public Server() {
            server = null;
            port = 14242;
            localHost = IPAddress.Parse("127.0.0.1");
            bytes = new byte[256];
            server = new TcpListener(localHost, port);
            clients = new List<TcpClient>();
        }

        public void Connect() {
            Thread connectThread = new Thread(ConnectClient);
            connectThread.IsBackground = true;
            connectThread.Start();
        }

        private void ConnectClient() {
            server.Start();
            while (true) {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);

                Thread newThread = new Thread(() => readMessage(client));
                newThread.IsBackground = true;
                newThread.Start();

                // Send the game object first 
                SendGameToClients(currentGame);

                // Create and send Player object back to client. 
                Player play = new Player();
                sendPlayerObject(client, play);

                TestHarnessViewModel.Status += "Client Connected!\n";
            }
        }

        private void readMessage(object obj) {
            while (true) {
                try {
                    TcpClient client = (TcpClient)obj;

                    string data = null;
                    string fullData = "";

                    NetworkStream stream = client.GetStream();

                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        fullData += data;
                        if (!stream.DataAvailable) break;
                    }

                    currentGame = DeserializeObject(fullData);

                } catch (Exception ex) {
                    // Process exception
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SendGameToClients(Game game) {
            foreach (TcpClient c in clients) {
                writeMessage(c, game);
            }
        }

        private void sendPlayerObject(object obj, Player play) {
            try {
                TcpClient client = (TcpClient)obj;

                NetworkStream stream = client.GetStream();

                string playerString = SerializeObject(play);

                byte[] message = System.Text.Encoding.ASCII.GetBytes(playerString);

                stream.Write(message, 0, message.Length);
            } catch (Exception ex) {
                // Process exception
                MessageBox.Show(ex.Message);
            }
        }

        private void writeMessage(object obj, Game game) {
            try {
                TcpClient client = (TcpClient)obj;

                NetworkStream stream = client.GetStream();

                gameString = SerializeObject(game);

                byte[] message = System.Text.Encoding.ASCII.GetBytes(gameString);

                stream.Write(message, 0, message.Length);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        // Shamelessly stolen from:
        // https://stackoverflow.com/questions/2434534/serialize-an-object-to-string
        private Game DeserializeObject(string gameText) {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (TextReader reader = new StringReader(gameText)) {
                Game result = (Game)serializer.Deserialize(reader);
                return result;
            }
        }

        // Shamelessly modified from:
        // https://stackoverflow.com/questions/10518372/how-to-deserialize-xml-to-object
        private string SerializeObject<T>(T toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter()) {
                xmlSerializer.Serialize(textWriter, toSerialize);

                return textWriter.ToString();
            }
        }
    }
}
