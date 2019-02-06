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

        private void updateDisplay()
        {
            TextBlock[] buttonLabels = new TextBlock[9];
            buttonLabels[0] = tbSquare0;
            buttonLabels[1] = tbSquare1;
            buttonLabels[2] = tbSquare2;
            buttonLabels[3] = tbSquare3;
            buttonLabels[4] = tbSquare4;
            buttonLabels[5] = tbSquare5;
            buttonLabels[6] = tbSquare6;
            buttonLabels[7] = tbSquare7;
            buttonLabels[8] = tbSquare8;

            for(int i = 0; i < game.GameBoard.Spaces.Count; i++)
            {
                Property property = (Property)game.GameBoard.Spaces[i];
                if(property.Owner != -1)
                {
                    Player owner = game.getPlayerById(property.Owner);
                    buttonLabels[i].Text = owner.Token;
                }

            }
            if (game.GameState == GameStates.GameOver) 
            {
                MessageBox.Show("Game over!");
            }
        }

        private void BtnSquare6_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(6);
            updateDisplay();
        }

        private void BtnSquare7_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(7);
            updateDisplay();
        }

        private void BtnSquare8_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(8);
            updateDisplay();
        }

        private void BtnSquare3_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(3);
            updateDisplay();
        }

        private void BtnSquare4_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(4);
            updateDisplay();
        }

        private void BtnSquare5_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(5);
            updateDisplay();
        }

        private void BtnSquare0_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(0);
            updateDisplay();
        }

        private void BtnSquare1_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(1);
            updateDisplay();
        }

        private void BtnSquare2_Click(object sender, RoutedEventArgs e)
        {
            game.handleTurn(2);
            updateDisplay();
        }
    }
}
