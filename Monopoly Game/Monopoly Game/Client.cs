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

        public Client() {
            server = "127.0.0.1";
        }

        public void ConnectToServer() {
            Thread newThread = new Thread(Connect);
            newThread.Start();
        }

        private void Connect() {
            client = new TcpClient(server, port);
            ThreadPool.QueueUserWorkItem(Read, client);
        }

        private void Read(object obj) {
            try {
                byte[] bytes = new byte[256];
                string data = null;

                NetworkStream stream = client.GetStream();

                int i;

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) { // Will bytes being a global variable mess with this?????
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                }

                Game currentGame = DeserializeObject(data);
                // Return the game object to the caller

            } catch (Exception ex) {

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

        // Shameless stolen from:
        // https://stackoverflow.com/questions/10518372/how-to-deserialize-xml-to-object
        private Game DeserializeObject(string gameText) {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (TextReader reader = new StringReader(gameText)) {
                Game result = (Game)serializer.Deserialize(reader);
                return result;
            }
        }
    }
}
