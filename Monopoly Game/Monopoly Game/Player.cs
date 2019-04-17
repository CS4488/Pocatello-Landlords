﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
        private Ellipse _PlayerCircle;

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

        public Image TokenImage { get { return _TokenImage; } set { _TokenImage = value; } }
        public Ellipse PlayerCircle { get { return _PlayerCircle; } set { _PlayerCircle = value; } } // R.C. Added 17 APR 2019

        public int Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public Player()
        {
            this._ID = Player.lastAssignedId;
            Player.lastAssignedId++;

            // M.S. The player is assigned a new color using the player ID as an index to the enum in PlayerColor
            this._TokenColor = PlayerColor.AssignColor(_ID);

            // R.C. Replaced .png image as token for an Ellipse object - 17 APR 2019
            _PlayerCircle = new Ellipse();
            SolidColorBrush brush = new SolidColorBrush(_TokenColor);
            _PlayerCircle.Fill = brush;
            
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