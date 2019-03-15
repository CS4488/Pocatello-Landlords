using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace TcpListener_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void startServer()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 0;
                IPAddress localAddr = IPAddress.Parse("0.0.0.0");
                // Set the TcpListener on port.
                // Must call invoke because the main thread owns these controls. - Tyler
                this.Dispatcher.Invoke(() =>
                {
                    port = int.Parse(txtHostingPortNumber.Text);
                    localAddr = IPAddress.Parse(txtHostingIP.Text);
                });
                
                

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();
                this.Dispatcher.Invoke(() =>
                {
                    tbServerText.Text += "Server started on: " + localAddr.ToString() + ":" + port.ToString() + "\r\n";
                });

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    TcpClient client = new TcpClient();
                    //Console.Write("Waiting for a connection... ");
                    this.Dispatcher.Invoke(() =>
                    {
                        tbServerText.Text += "Waiting for a connection...\r\n";
                    });
                    

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");


                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                //Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            //Console.WriteLine("\nHit enter to continue...");
            //Console.Read();
        }
        void Connect(String server, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = int.Parse(txtConnectingPortNumber.Text);
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                //Console.WriteLine("Sent: {0}", message);
                tbClientText.Text += "Sent: " + message + "\r\n";

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);
                tbClientText.Text += "Received: " + responseData + "\r\n";

                // Close everything.
                stream.Close();
                client.Close();
                tbErrors.Text = "";
            }
            catch (ArgumentNullException e)
            {
                //Console.WriteLine("ArgumentNullException: {0}", e);
                tbErrors.Text = "ArgumentNullException: " + e;
            }
            catch (SocketException e)
            {
                //Console.WriteLine("SocketException: {0}", e);
                tbErrors.Text = "SocketException: " + e;
            }

            //Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }

        private void btnHostServer_Click(object sender, RoutedEventArgs e)
        {
            new Thread(delegate () {
                startServer();
            }).Start();
            MessageBox.Show("Server Started!");
        }

        private void btnJoinServer_Click(object sender, RoutedEventArgs e)
        {
            Connect(txtConnectingIP.Text, txtMessage.Text);
        }
    }
}
