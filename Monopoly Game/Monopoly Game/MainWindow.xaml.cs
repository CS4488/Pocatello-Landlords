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

        private void BtnSquare6_Click(object sender, RoutedEventArgs e)
        {
            makeMove(6, tbSquare6);
        }

        private void BtnSquare7_Click(object sender, RoutedEventArgs e)
        {
            makeMove(7, tbSquare7);
        }

        private void BtnSquare8_Click(object sender, RoutedEventArgs e)
        {
            makeMove(8, tbSquare8);
        }

        private void BtnSquare3_Click(object sender, RoutedEventArgs e)
        {
            makeMove(3, tbSquare3);
        }

        private void BtnSquare4_Click(object sender, RoutedEventArgs e)
        {
            makeMove(4, tbSquare4);
        }

        private void BtnSquare5_Click(object sender, RoutedEventArgs e)
        {
            makeMove(5, tbSquare5);
        }

        private void BtnSquare0_Click(object sender, RoutedEventArgs e)
        {
            makeMove(0, tbSquare0);
        }

        private void BtnSquare1_Click(object sender, RoutedEventArgs e)
        {
            makeMove(1, tbSquare1);
        }

        private void BtnSquare2_Click(object sender, RoutedEventArgs e)
        {
            makeMove(2, tbSquare2);
        }
        private void makeMove(int propertyNumber, TextBlock button)
        {
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(propertyNumber);

            if (prop.owner == -1)
            {
                prop.owner = playerID;
                game.GameBoard.Spaces[propertyNumber] = prop;
                if (playerID == 0)
                {
                    button.Text = "X";
                }
                else
                {
                    button.Text = "O";
                }
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin())
                {
                    MessageBox.Show("You Win!");
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }
    }
}
