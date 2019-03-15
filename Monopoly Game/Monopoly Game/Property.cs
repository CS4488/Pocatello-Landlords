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
        public int _value, owner;

        public int Owner { get{ return owner; } set{ owner = value; } }
        public int Value { get{ return _value; } set{ value = _value; } }
        public Property()
        {
            owner = -1;
            _value = 0;
        }

        /// <summary>
        /// This constructor for use with the Tic Tac Toe test harness
        /// Rex Christensen - 27JAN2019 - v1
        /// </summary>
        /// <param name="inputValue"></param>
        public Property(int inputValue) {
            owner = -1;
            _value = inputValue;
        }

        public Property(int inputOwner, int inputValue)
        {
            owner = inputOwner;
            _value = inputValue;
        }
    }
}
