﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    /*
     * Rex Christesnsen: Game class 1.0
     * 
     * Please describe changes made here; along with your name, date, and version:
     * Created public Constructor - Rex Christensen - 27JAN1019 - v1
     * 
     * Moved Fernando's method of Win Condition Check to this class. Michael Sterner - 20JAN2019 - v1
     * 
     */
    class TicTacToe : Game
    {
        public TicTacToe()
        {
            for (int i = 0; i < 9; i++)
                base.GameBoard.Spaces.AddLast(new Property(i));// For tictactoe, owner is a needed variable, so type property is used
        }
        /*
         * Author: Fernando Munoz
         * Date: January 28th, 2019
         * Method: Win Condition Check
         * Version: 1.0
         * 
         * Description: Checks the gameBoard spaces for a 3-in-a-row match. Returns true if win condition found. 
         *              Will also end program. We might want to change this. :P
         */
        public bool checkForTicTacToeWin()
        {

            // Temporary cast while the list is changed to an array
            Property[] temp = base.GameBoard.Spaces.Cast<Property>().ToArray();

            // Horizontal checks
            for (int i = 0; i < 8; i += 3)
            {
                if (temp[i].owner == temp[i + 1].owner && temp[i].owner == temp[i + 2].owner && temp[i].owner != -1)
                {
                    return true;
                }
            }

            // Vertical checks
            for (int i = 0; i < 3; i++)
            {
                if (temp[i].owner == temp[i + 3].owner && temp[i].owner == temp[i + 6].owner && temp[i].owner != -1)
                {
                    return true;
                }
            }

            // Diagonal checks
            if (temp[0].owner == temp[4].owner && temp[0].owner == temp[8].owner && temp[0].owner != -1)
            {
                return true;
            }

            if (temp[2].owner == temp[4].owner && temp[2].owner == temp[6].owner && temp[2].owner != -1)
            {
                return true;
            }

            return false;
        }
    }

}
