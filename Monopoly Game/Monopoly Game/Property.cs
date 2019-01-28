using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    /*
         * Rex Christesnsen: Property class 1.0
         * 
         * Please describe changes made here; along with your name, date, and version:
         * Addws public Constructor for use with Tic Tac Toe test harness - Rex Christensen - 27JAN1019 - v1
         * 
         */
    class Property : Space
    {
        public int value, owner;
        public Property()
        {
            owner = -1;
            value = 0;
        }

        /// <summary>
        /// This constructor for use with the Tic Tac Toe test harness
        /// Rex Christensen - 27JAN2019 - v1
        /// </summary>
        /// <param name="inputValue"></param>
        public Property(int inputValue) {
            owner = -1;
            value = inputValue;
        }

        public Property(int inputOwner, int inputValue)
        {
            owner = inputOwner;
            value = inputValue;
        }
    }
}
