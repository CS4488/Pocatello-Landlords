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
    * M.S. Made the makeMove function more generic, so as to accept moves that are not dependent on player clicks... This was
    * done to make it possible for the computer player to input a move. M.S. - 30JAN2019
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
            makeMove(6);
        }

        private void BtnSquare7_Click(object sender, RoutedEventArgs e)
        {
            makeMove(7);
        }

        private void BtnSquare8_Click(object sender, RoutedEventArgs e)
        {
            makeMove(8);
        }

        private void BtnSquare3_Click(object sender, RoutedEventArgs e)
        {
            makeMove(3);
        }

        private void BtnSquare4_Click(object sender, RoutedEventArgs e)
        {
            makeMove(4);
        }

        private void BtnSquare5_Click(object sender, RoutedEventArgs e)
        {
            makeMove(5);
        }

        private void BtnSquare0_Click(object sender, RoutedEventArgs e)
        {
            makeMove(0);
        }

        private void BtnSquare1_Click(object sender, RoutedEventArgs e)
        {
            makeMove(1);
        }

        private void BtnSquare2_Click(object sender, RoutedEventArgs e)
        {
            makeMove(2);
        }
        private void makeMove(int propertyNumber)
        {
            int move = 0;
            playerID = game.CurrentPlayer.PlayerID;
            Property prop = getProperty(propertyNumber);
            actualizeDisplay(propertyNumber);
            if (prop.owner == -1)
            {
                prop.owner = playerID;
                game.GameBoard.Spaces[propertyNumber] = prop;
                game.makeNextPlayersTurn();
                if (game.checkForTicTacToeWin())
                {
                    MessageBox.Show("Game Over!");
                    System.Windows.Application.Current.Shutdown();
                    return;//M.S.~ Didn't know this, but the script continues after the window is shutdown, which will throw an error
                }
                if (game.CurrentPlayer is CompPlayer)
                {// M.S.~ Computer player turn is handled here.
                    move = game.CurrentPlayer.TakeTurn(game.GameBoard);
                    if (move <= -1)
                    {
                        MessageBox.Show("Stale-mate");
                        System.Windows.Application.Current.Shutdown();
                        return;
                    }
                    else makeMove(move);
                }
            }
        }
        private void actualizeDisplay(int propertyNum)
        {
            if (propertyNum == 0) actualizeButton(tbSquare0);
            if (propertyNum == 1) actualizeButton(tbSquare1);
            if (propertyNum == 2) actualizeButton(tbSquare2);
            if (propertyNum == 3) actualizeButton(tbSquare3);
            if (propertyNum == 4) actualizeButton(tbSquare4);
            if (propertyNum == 5) actualizeButton(tbSquare5);
            if (propertyNum == 6) actualizeButton(tbSquare6);
            if (propertyNum == 7) actualizeButton(tbSquare7);
            if (propertyNum == 8) actualizeButton(tbSquare8);
        }
        private void actualizeButton(TextBlock button)
        {
            if (playerID == 0)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "O";
            }
        }
    }
}
