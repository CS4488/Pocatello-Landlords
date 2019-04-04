using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    /*
     * Rex Christensen: Board class 1.0
     * 
     * 
     * Please describe changes made here; along with your name, date, and version:
     * Created constructor that instantiate the spaces linkedList - Rex Christensen - 27JAN2019 - v1
     * Changed the spaces variable to private and implemented a public property - 27JAN2019 - v1
     * Changed LinkedList to List object - Rex Christensen - 28JAN2019 - v1
     * 
     */
    class Board
    {
        List<Space> spaces;

        public List<Space> Spaces { get { return spaces; } set { spaces = value; } }

        public Board() {
            spaces = new List<Space>();
        }
        public Board(List<Space> boardSpaces)
        {
            spaces = boardSpaces;
        }
    }
}
