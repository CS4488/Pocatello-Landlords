using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Monopoly_Game
{
    class Player
    {
        protected static int lastAssignedId = 0;

        private int playerID;
        private bool eliminated = false;
        private string playerName;
        private string token;
        private int _Position;
        private Space _CurrentSpace;
        private Image _TokenImage;

        public string PlayerName { get { return playerName; } set { playerName = value; } }
        public int PlayerID { get { return playerID; } set { playerID = value; } }
        public bool Eliminated { get { return eliminated; } set { eliminated = value; } }
        public string Token { get { return token; } set { token = value; } }
        public static int LastAssignedID { get { return lastAssignedId; } set { lastAssignedId = value; } }
        public Space CurrentSpace { get { return _CurrentSpace; } set { _CurrentSpace = value; } }

        public Image TokenImage { get { return _TokenImage; } set { _TokenImage = value; } }

        public int Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public Player()
        {
            this.playerID = Player.lastAssignedId;
            Player.lastAssignedId++;
        }

        public Player(int inputID)
        {
            playerID = inputID;
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