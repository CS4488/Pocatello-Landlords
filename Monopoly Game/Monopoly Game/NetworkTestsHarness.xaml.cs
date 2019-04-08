﻿using System;
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

namespace Monopoly_Game
{
    /// <summary>
    /// Interaction logic for NetworkTestsHarness.xaml
    /// </summary>

    /*
    * Rex Christesnsen: NetworkTestHarness.xaml.cs version 1.0 3/30/2019
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Methods and logic to control the Test Harness
    */

    public partial class NetworkTestsHarness : Window {
        Game currentGame;
        Server server;
        Client client;

        public NetworkTestsHarness() {
            InitializeComponent();
        }

        private void BtnCreateGame_Click(object sender, RoutedEventArgs e) {
            List<Space> spaces = new List<Space>();
            currentGame = new Game(spaces); 
            TestHarnessViewModel.Status += "Game Created!\n";
        }

        private void BtnHostGame_Click(object sender, RoutedEventArgs e) {
            server = new Server();
            server.Connect();
            if (currentGame != null) {
                server.CurrentGame = currentGame;
            }
            TestHarnessViewModel.Status += "Waiting for connection...\n";
        }

        private void BtnJoinGame_Click(object sender, RoutedEventArgs e) {
            client = new Client();
            client.ConnectToServer();
        }

        private void BtnEndTurn_Click(object sender, RoutedEventArgs e) {
            if (server != null) {
                currentGame.makeNextPlayersTurn();
                server.SendGameToClients(currentGame);
                updateDisplay();
                return;
            } else if (client != null) {
                currentGame.makeNextPlayersTurn();
                client.SendMessage(currentGame);
                updateDisplay();
                return;
            }
        }

        private void BtnInitialUpdate_Click(object sender, RoutedEventArgs e) {
            updateDisplay();
        }

        public void updateDisplay() {
            if (server != null) {
                currentGame = server.CurrentGame;
            } else if (client != null) {
                currentGame = client.CurrentGame;
            }
            TestHarnessViewModel.CurrentPlayer = currentGame.CurrentPlayer.PlayerID.ToString(); 
            TestHarnessViewModel.NumPlayers = currentGame.Players.Count.ToString();
            TestHarnessViewModel.State = currentGame.GameState.ToString();
            TestHarnessViewModel.MyPlayer = currentGame.MyPlayer.PlayerID.ToString(); // This is throwing null reference error
        }
    }
}