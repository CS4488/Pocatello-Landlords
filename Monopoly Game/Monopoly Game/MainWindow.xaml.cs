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
    public partial class MainWindow : Window
    {
        TicTacToe game;
        int playerID;
        public MainWindow()
        {
            InitializeComponent();
            game = new TicTacToe();
        }

        private LinkedListNode<Space> getCurrentNode(int square){
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(square);

            int i = 0;
            LinkedListNode<Space> currentNode = game.GameBoard.Spaces.First;
            while (i < square) {
                currentNode = currentNode.Next;
                i++;
            }

            return currentNode;
        }

        private void BtnSquare6_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(6);

            LinkedListNode<Space> currentNode = getCurrentNode(6);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare6.Text = "X";
                } else {
                    tbSquare6.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare7_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(7);

            LinkedListNode<Space> currentNode = getCurrentNode(7);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare7.Text = "X";
                } else {
                    tbSquare7.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare8_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(8);

            LinkedListNode<Space> currentNode = getCurrentNode(8);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare8.Text = "X";
                } else {
                    tbSquare8.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare3_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(3);

            LinkedListNode<Space> currentNode = getCurrentNode(3);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare3.Text = "X";
                } else {
                    tbSquare3.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare4_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(4);

            LinkedListNode<Space> currentNode = getCurrentNode(4);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare4.Text = "X";
                } else {
                    tbSquare4.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare5_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(5);

            LinkedListNode<Space> currentNode = getCurrentNode(5);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare5.Text = "X";
                } else {
                    tbSquare5.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare0_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(0);

            LinkedListNode<Space> currentNode = game.GameBoard.Spaces.First;

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare0.Text = "X";
                } else {
                    tbSquare0.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare1_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(1);

            LinkedListNode<Space> currentNode = getCurrentNode(1);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare1.Text = "X";
                } else {
                    tbSquare1.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }

        private void BtnSquare2_Click(object sender, RoutedEventArgs e) {
            playerID = game.CurrentPlayer.playerID;
            Property prop = (Property)game.GameBoard.Spaces.ElementAt(2);

            LinkedListNode<Space> currentNode = getCurrentNode(2);

            if (prop.owner == -1) {
                prop.owner = playerID;
                currentNode.Value = prop;
                if (playerID == 0) {
                    tbSquare2.Text = "X";
                } else {
                    tbSquare2.Text = "O";
                }
                game.makeNextPlayersTurn();
                game.checkForTicTacToeWin();
            }
        }
    }
}
