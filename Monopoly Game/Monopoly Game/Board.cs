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
     * 
     */
    class Board
    {
        LinkedList<Space> spaces;

        public LinkedList<Space> Spaces { get { return spaces; } set { spaces = value; } }

        public Board() {
            spaces = new LinkedList<Space>();
        }
    }
}
