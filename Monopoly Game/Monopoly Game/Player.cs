using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class Player
    {
        public int playerID;
        public bool eliminated = false;
        public Player()
        { }
        public Player(int inputID)
        {
            playerID = inputID;
        }
        public void takeTurn()
        {
            // Commented out so Test Harness would compile - Rex Christensen - 27JAN2019 - v1;
            //moveToSpace();
            //interactWithSpace();
        }
    }
    

}
