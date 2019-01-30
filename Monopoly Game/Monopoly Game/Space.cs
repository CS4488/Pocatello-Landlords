using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class Space
    {
        string spaceName;

        public string SpaceName { get{ return spaceName; } set{ spaceName = value; } }
        public Space()
        {
            spaceName = " ";
        }
        public Space(string inputName)
        {
            spaceName = inputName;
        }
    }
}
