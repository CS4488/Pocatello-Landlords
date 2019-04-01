using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly_Game
{
    class MonopolyDisplayManager
    {
        // TODO: The following is a list of methods that the Landlords game should be able to handle.
        //      We should keep in mind that everything the gameBoard class should be responsible for is
        //      display logic.
        //
        /*  There will be more as the game is developed, and we may want to change around the way things are organized
         *  This list is not exhaustive...
         *  
         *  Gameboard Update Methods
         *       1. Move game peice (int player#, int numberSpaces), (int player#, Button destination)
         * CHECK 2. Display dice roll value (int rollValue)
         *       3. Update player properties(List properties)
         *       4. Update opponent properties( List<Pair<Player, List<Properties>>>, or something like this)
         *       5. Update player cards
         *       6. Display Endgame Gamestate (You won, You lost, Draw... and show message accordingly)
         *       7. Update current player's turn
         *       8. Show other player actions (dice rolls, properties (bought, sold, etc), cards drawn...)
         *  
         *  Player Actions
         *      1. Buy property
         *      2. Draw card
         *      3. Use card
         *      4. Build on property
         *      5. Roll dice
         */

        #region Game Initialized Methods
        public void DiceRoll()
        {
            MessageBox.Show("Roll the Dice", "Roll");

            // Call game and have it return a value for the dice roll
            // int d1 = Game.RollDice();
            // int d2 = Game.RollDice();
            int d1 = 6;
            int d2 = 3;

            MessageBox.Show(String.Concat("You rolled {0} and {1}", d1, d2));
            // Game should, after this, call a move Piece method
        }


        public void MovePlayer(int playerID, int numberOfSpaces)
        {

        }

        public void MovePlayer(int playerID, String nameOfSpace)
        {

        }

        public void EndGameMessage(String message)
        {
            MessageBox.Show("You " + message);
        }
        #endregion



        #region Player Initialized Methods

        public void InspectProperty()
        {

        }
        #endregion
    }
}