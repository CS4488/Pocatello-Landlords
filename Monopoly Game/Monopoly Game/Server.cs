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
                //ThreadPool.QueueUserWorkItem(readMessage, client);
                Thread newThread = new Thread(() => readMessage(client));
                newThread.IsBackground = true;
                newThread.Start();
            }
        }

        private void readMessage(object obj) {
            try {
                TcpClient client = (TcpClient)obj;

                string data = null;

                NetworkStream stream = client.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    // Deserialize data back into a game object
                    Game currentGame = DeserializeObject(data);
                    // ************** Return game object back to caller ****************
                    // Maybe call an event handler that sends the new game object somewhere????
                }

                return; 
            } catch (Exception ex) {
                // Process exception
            }
        }

        public void SendToClients(Game game) {
            foreach (TcpClient c in clients) {
                writeMessgae(c, game);
            }
        }

        private void writeMessgae(object obj, Game game) {
            try {
                TcpClient client = (TcpClient)obj;

                NetworkStream stream = client.GetStream();

                data = SerializeObject(game);

                byte[] message = System.Text.Encoding.ASCII.GetBytes(data);
            } catch (Exception ex) {
                // process exception
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
