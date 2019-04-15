using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Monopoly_Game
{
    class Player
    {
        protected static int lastAssignedId = 0;

        private int _ID;
        private bool _Eliminated = false;
        private string _Name;
        private int _Position;
        private Space _CurrentSpace;
        private Image _TokenImage;
        private Color _TokenColor;
        private Token _Token;

        public string PlayerName {
            get { return _Name; }
            set { _Name = value; }
        }

        public int PlayerID {
            get { return _ID; }
            set { _ID = value; }
        }

        public bool Eliminated {
            get { return _Eliminated; }
            set { _Eliminated = value; }
        }

        public Token Token {
            get { return _Token; }
            set { _Token = value; }
        }

        public static int LastAssignedID {
            get { return lastAssignedId; }
            set { lastAssignedId = value; }
        }

        public Space CurrentSpace {
            get { return _CurrentSpace; }
            set { _CurrentSpace = value; }
        }

        public Image TokenImage { get { return _TokenImage; } set { _TokenImage = value; } }

        public int Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public Player()
        {
            this._ID = Player.lastAssignedId;
            Player.lastAssignedId++;
        }

        public Player(int inputID)
        {
            _ID = inputID;
        }

        public virtual bool takeTurn(int spaceIndex, Game game)
        {
            bool validTurn = false;
            Space spaceClicked = game.GameBoard.Spaces[spaceIndex];
            if (spaceClicked is Property)
            {
                Property propertyClicked = (Property)spaceClicked;
                if (propertyClicked.OwnerPlayerID == -1)
                {
                    propertyClicked.OwnerPlayerID = game.CurrentPlayer.PlayerID;
                    validTurn = true;
                }
            }
            return validTurn;
        }
    }
}