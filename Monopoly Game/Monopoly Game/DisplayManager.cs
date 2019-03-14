/*
 * Handles displaying game
 * Kalen Williams
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Monopoly_Game
{
    class DisplayManager
    {
        Game game;
        Grid grid;

        public DisplayManager(Game game, Grid grid)
        {
            this.game = game;
            this.grid = grid;
        }

        public void updateDisplay()
        {
            grid.Visibility = Visibility.Visible;
            grid.IsEnabled = true;

            for(int i = 0; i < game.GameBoard.Spaces.Count; i++)
            {
                Property property = (Property)game.GameBoard.Spaces[i];
                if(property.Owner != -1)
                {
                    Player owner = game.getPlayerById(property.Owner);
                    //our buttons are indexed same as grid
                    Button btn = (Button)grid.Children[i];
                    var btnLabel = btn.Content as TextBlock;
                    btnLabel.Text = owner.Token;
                }
                else
                {
                    Button btn = (Button)grid.Children[i];
                    var btnLabel = btn.Content as TextBlock;
                    btnLabel.Text = "";
                }
            } 
            if(game.GameState == GameStates.GameOver)
            {
                MessageBox.Show("Game over!");
            }
        }



        /// <summary>
        /// Call to Game to run dice roll logic and get dice values
        /// </summary>
        public void Game_InitiateDiceRoll()
        {
            MessageBox.Show("Best of luck...", "DICE ROLL");
            Tuple<int, int> dice = game.InitateDiceRoll();

            MessageBox.Show("You rolled...", String.Concat("... a {0] and {1}", dice.Item1, dice.Item2));
        }


    }
}
