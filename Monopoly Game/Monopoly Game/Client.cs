using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows;

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

                // Deserialize data

            } catch (Exception ex) {

            }
        }

        public void SendMessage() {
            Thread sendThread = new Thread(Send); // This will need to be a paramaterized thread, or use a ThreadPool as the Read does
            sendThread.Start();
        }

        private void Send() { // Pass in the game object to serialize it, or serialize then pass in the txt file
            string message = null; // *********** serialize the game object into a txt file here ************
            try {
                // Here we will want to serialize the object, or send it as a .txt file that can then be interpreted by the game class.
                // Possible serialize the game object as an .XML object
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                //stream.Close();
                //client.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
