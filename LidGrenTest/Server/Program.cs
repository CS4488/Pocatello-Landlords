using System;
using System.Threading;

namespace Server

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var server = new Server();
            server.StartServer();
            ThreadStart listenThreadStart = new ThreadStart(server.ReadMessages);
            Thread listenThread = new Thread(listenThreadStart);
            listenThread.Start();
            //server.ReadMessages();

            while (true) {
                var text = Console.ReadLine();
                server.SendMessage(text);

                if (text == "exit") {
                    break;
                }
            }

            //server.Disconnect();
        }
    }
}
