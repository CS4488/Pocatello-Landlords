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
    /// Interaction logic for GameParameters.xaml
    /// </summary>

    /*
    * Rex Christesnsen: GameParameters.xaml.cs class 1.0 - 12 MAR 2019
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Window for the user to select game and basic game parameters
    */
    public partial class GameParameters : Window {
        string selectedGame = "";
        int numberOfAIPlayers;
        int numberOfNetworkPlayers;
        string selectedToken = "";
        Game newGame;

        public GameParameters() {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e) {
            if (selectedGame == "Tic Tac Toe") {
                newGame = new TicTacToe();
                // This is currently covered in constructor of Tic Tac Toe. 
                //if (numberOfAIPlayers > 0) {
                //    addPlayersToGame(newGame);
                //}
            } else {
                List<Space> spaces = new List<Space>();
                newGame = new Game(spaces);
                if (numberOfAIPlayers > 0) {
                    addPlayersToGame(newGame);
                }
            }
        }

        private void addPlayersToGame(Game newGame) {
            for (int i = 0; i < numberOfAIPlayers; i++) {
                Player p = new Player();
                newGame.Players.Add(p);
            }
        }

        private void fillTokenList() {
            if (selectedGame == "Monopoly") {
                // Do stuff
            } else if (selectedGame == "Tic Tac Toe") {
                // Do stuff
                ComboBoxItem itemX = new ComboBoxItem();
                ComboBoxItem itemO = new ComboBoxItem();
                itemX.Content = "X";
                itemO.Content = "O";
                cmbToken.Items.Add(itemX);
                cmbToken.Items.Add(itemO);
            } else {
                // Do nothing
            }
        }

        private void cmbChooseGame_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedGame = cmbChooseGame.Text;
            fillTokenList();
        }
    }
}
