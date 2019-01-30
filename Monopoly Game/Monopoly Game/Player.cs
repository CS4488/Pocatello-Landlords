using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class Player
    {
        int playerID;
        bool eliminated = false;
        string playerName;

        public string PlayerName { get{ return playerName; } set{ playerName = value; } }
        public int PlayerID { get{ return playerID; } set{ playerID = value; } }
        public bool Eliminated { get{return eliminated; } set{ eliminated = value; } }
        
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
