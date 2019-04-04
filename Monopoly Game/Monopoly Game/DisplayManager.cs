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
                if(property.OwnerPlayerID != -1)
                {
                    Player owner = game.getPlayerById(property.OwnerPlayerID);
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
    }
}
