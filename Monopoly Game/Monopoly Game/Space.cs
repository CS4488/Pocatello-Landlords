using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class Space
    {
        private String _Name;

        public string SpaceName { get{ return _Name; } set{ _Name = value; } }


        public Space()
        {
            _Name = String.Empty;
        }

        public Space(string inputName)
        {
            _Name = inputName;
        }
    }
}
