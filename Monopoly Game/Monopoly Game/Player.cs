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
        private Button _TokenImage;
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
        public Color TokenColor{ //M.S. Added 4/16/19
            get { return _TokenColor; }
            set { _TokenColor = value; }
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

//<<<<<<< HEAD
        public Button TokenImage { get { return _TokenImage; } set { _TokenImage = value; } }
//=======
        public Image TokenImage { get { return _TokenImage; } set { _TokenImage = value; } }
<<<<<<< HEAD
        public Ellipse PlayerCircle { get { return _PlayerCircle; } set { _PlayerCircle = value; } } // R.C. Added 17 APR 2019
//>>>>>>> e0ca2b0453c9b6f6e27ff863c528b1a8b605f0ed
=======
>>>>>>> parent of e0ca2b0... Changed to allow different color tokens

        public int Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public Player()
        {
            this._ID = Player.lastAssignedId;
            Player.lastAssignedId++;
            this._TokenColor = PlayerColor.AssignColor(_ID);
            // M.S. The player is assigned a new color using the player ID as an index to the enum in PlayerColor
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