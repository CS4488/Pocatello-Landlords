using System;
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
using System.Windows.Shapes;

namespace Monopoly_Game {
    /// <summary>
    /// Interaction logic for NetworkTestHarness.xaml
    /// </summary>
    public partial class NetworkTestHarness : Window {
        Game currentGame;
        Server server;
        Client client;
        public NetworkTestHarness() {
            InitializeComponent();
        }

        private void BtnCreateGame_Click(object sender, RoutedEventArgs e) {
            currentGame = new Game();
            TestHarnessViewModel.Status += "Game Created!\n";
        }

        private void BtnHostGame_Click(object sender, RoutedEventArgs e) {
            server = new Server();
            server.Connect();
            if (currentGame != null) {
                server.CurrentGame = currentGame;
            }
            TestHarnessViewModel.Status += "Waiting for connection...\n";
            //updateDisplay();
        }

        private void BtnJoinGame_Click(object sender, RoutedEventArgs e) {
            client = new Client();
            client.ConnectToServer();
            currentGame = client.CurrentGame;
            //updateDisplay();
        }

        private void BtnEndTurn_Click(object sender, RoutedEventArgs e) {
            if (server != null) {
                server.SendGameToClients(currentGame);
                updateDisplay();
                return;
            } else if (client != null) {
                client.SendMessage(currentGame);
                updateDisplay();
                return;
            }
        }

        public void updateDisplay() {
            TestHarnessViewModel.CurrentPlayer = currentGame.CurrentPlayer.PlayerID.ToString();
            TestHarnessViewModel.NumPlayers = currentGame.Players.Count.ToString();
            TestHarnessViewModel.State = currentGame.GameState.ToString();
            TestHarnessViewModel.MyPlayer = currentGame.MyPlayer.PlayerID.ToString();
            if (server != null) {
                currentGame = server.CurrentGame;
                return;
            } else if (client != null) {
                currentGame = client.CurrentGame;
                return;
            }
        }

        private void BtnInitialUpdate_Click(object sender, RoutedEventArgs e) {
            updateDisplay();
        }
    }
}
