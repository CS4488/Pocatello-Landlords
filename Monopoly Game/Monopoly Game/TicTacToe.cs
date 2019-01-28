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
     * 
     */
    class TicTacToe : Game
    {
        public TicTacToe()
        {
            for (int i = 0; i < 9; i++)
                base.GameBoard.Spaces.AddLast(new Property(i));// For tictactoe, owner is a needed variable, so type property is used
        }   
    }
}
