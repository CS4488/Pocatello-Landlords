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
    */
    class Server {
        TcpListener server;
        Int32 port;
        IPAddress localHost;
        byte[] bytes;
        string data;
        List<TcpClient> clients;
        Game currentGame;
        string gameString;

        public Game CurrentGame { get{ return currentGame; } set { currentGame = value; } }
        public List<TcpClient> Clients { get{ return clients; } }

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
            while(true) { // *************** Add some sort of exit flag here ********************** May not be needed
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);

                // Create and send Player object back to client. **** Does this need to be it's own thread? ****
                Player play = new Player();
                sendPlayerObject(client, play);

                // ***** For Test Harness ****
                SendGameToClients(currentGame);

                Thread newThread = new Thread(() => readMessage(client));
                newThread.IsBackground = true;
                newThread.Start();

                // ************ For Test Harness *************
                // Add some notification that a client has connected.
                TestHarnessViewModel.Status += "Client Connected!\n";

                //Application.Current.Dispatcher.Invoke(() => {
                //    foreach (Window w in Application.Current.Windows) {
                //        if (w.GetType() == typeof(NetworkTestHarness)) {
                //            (w as NetworkTestHarness).updateDisplay();
                //        }
                //    }
                //});
            }
        }

        private void readMessage(object obj) {
            try {
                TcpClient client = (TcpClient)obj;

                string data = null;
                string fullData = "";

                NetworkStream stream = client.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    // Deserialize data back into a game object
                    //currentGame = DeserializeObject(data);
                    // ************ Possibly some tag that the game has changed? ********
                    fullData += data;
                }

                currentGame = DeserializeObject(data);

                return; 
            } catch (Exception ex) {
                // Process exception
                MessageBox.Show(ex.Message);
            }
        }

        public void SendGameToClients(Game game) {
            foreach (TcpClient c in clients) {
                //c.Connect(localHost, port); // Will this create a new client in the Server list of clients?
                writeMessgae(c, game);
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

        private void writeMessgae(object obj, Game game) { // This client is not connected here for some reason
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

        private Game DeserializeObject(string gameText) {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (TextReader reader = new StringReader(gameText)) {
                Game result = (Game)serializer.Deserialize(reader);
                return result;
            }
        }

        private string SerializeObject<T>(T toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter()) {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
