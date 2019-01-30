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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    /*
    * Rex Christesnsen: MainWindow.xaml.cs class 1.0
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Added a Tic Tac Toe board composed of 9 buttons that will show either X or O depending on what player clicked on them - R.C. - 27JAN19
    * Adjusted the event handlers for each button to reflect change from LinkedList to List data structure - R.C. - 29JAN19 - v1
    * 
    */
    public partial class MainWindow : Window
    {
        TicTacToe game;
        int playerID;
        public MainWindow()
        {
            InitializeComponent();
            game = new TicTacToe();
        }

        private Property getProperty(int square) {
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(square);
            return prop;
        }

        private void BtnSquare6_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(6);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[6] = prop;
                if (playerID == 0) {
                    tbSquare6.Text = "X";
                } else {
                    tbSquare6.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare7_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(7);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[7] = prop;
                if (playerID == 0) {
                    tbSquare7.Text = "X";
                } else {
                    tbSquare7.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare8_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(8);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[8] = prop;
                if (playerID == 0) {
                    tbSquare8.Text = "X";
                } else {
                    tbSquare8.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare3_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(3); ;

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[3] = prop;
                if (playerID == 0) {
                    tbSquare3.Text = "X";
                } else {
                    tbSquare3.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare4_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(4);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[4] = prop;
                if (playerID == 0) {
                    tbSquare4.Text = "X";
                } else {
                    tbSquare4.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare5_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(5);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[5] = prop;
                if (playerID == 0) {
                    tbSquare5.Text = "X";
                } else {
                    tbSquare5.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare0_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(0);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[0] = prop;
                if (playerID == 0) {
                    tbSquare0.Text = "X";
                } else {
                    tbSquare0.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare1_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(1);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[1] = prop;
                if (playerID == 0) {
                    tbSquare1.Text = "X";
                } else {
                    tbSquare1.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void BtnSquare2_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(2);

            if (prop.owner == -1) {
                prop.owner = playerID;
                game.GameBoard.Spaces[2] = prop;
                if (playerID == 0) {
                    tbSquare2.Text = "X";
                } else {
                    tbSquare2.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin()) {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }
    }
}
