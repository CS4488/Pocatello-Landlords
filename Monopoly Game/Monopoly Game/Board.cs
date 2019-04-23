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
        List<Space> _Spaces;
        private int _PlayableSpaceCount;

        public List<Space> Spaces { get { return _Spaces; } set { _Spaces = value; } }

        public Board() {
            _Spaces = new List<Space>();
        }
        public Board(List<Space> boardSpaces)
        {
            _Spaces = boardSpaces;
        }
        public int PlayableSpaceCount
        {
            get
            {
                if(_PlayableSpaceCount == 0)
                {
                    _PlayableSpaceCount = SetPlayableSpaces();
                }
                return _PlayableSpaceCount;
            }
        }
        
        private int SetPlayableSpaces()
        {
            int count = 0;
            foreach(Space s in _Spaces)
            {
                if (s.Playable)
                {
                    count++;
                }
            }
            return count;
        }

        // Why arent we using a linked list again?
        public Space GetNextSpace(Space current)
        {
            int currNdx = _Spaces.IndexOf(current);

            if ( currNdx == _Spaces.Count - 1)
            {
                return _Spaces[0];
            }
            return _Spaces.ElementAt(currNdx + 1);
        }

        public Space GetNextPlayableSpace(Space current)
        {
            if(GetNextSpace(current).Playable == false)
            {
                return GetNextSpace(GetNextSpace(current));
            }
            return GetNextSpace(current);
        }
    }
}
