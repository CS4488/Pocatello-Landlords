using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

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
                ThreadPool.QueueUserWorkItem(readMessage, client);
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
                }

                return; 
            } catch (Exception ex) {
                // Process exception
            }
        }

        public void SendToClients() {
            foreach (TcpClient c in clients) {
                writeMessgae(c);
            }
        }

        private void writeMessgae(object obj) {
            try {
                TcpClient client = (TcpClient)obj;

                NetworkStream stream = client.GetStream();

                data = null; // *** serialize the object here

                byte[] message = System.Text.Encoding.ASCII.GetBytes(data);
            } catch (Exception ex) {
                // process exception
            }
        }
    }
}
