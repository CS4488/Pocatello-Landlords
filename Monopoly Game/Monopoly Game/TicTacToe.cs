using System;
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
     * Adjusted the adding of new properties to reflect the List data structure instead of the LinkedList - R.C. - 29JAN19 - v1
     * 
     */
    class TicTacToe : Game
    {
        public TicTacToe()
        {
            for (int i = 0; i < 9; i++)
                base.GameBoard.Spaces.Add(new Property(i));// For tictactoe, owner is a needed variable, so type property is used
        }

        public bool checkForTicTacToeWin() {
            bool win = false;
            // Check for horizontal wins

            // Check for verticle wins

            // Check for diagonal wins

            return win;
        }
    }
}
