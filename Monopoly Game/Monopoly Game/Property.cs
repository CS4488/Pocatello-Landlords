using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class Property : Space
    {
        public int value, owner;
        public Property()
        {
            owner = -1;
            value = 0;
        }
        public Property(int inputOwner, int inputValue)
        {
            owner = inputOwner;
            value = inputValue;
        }
    }
}
