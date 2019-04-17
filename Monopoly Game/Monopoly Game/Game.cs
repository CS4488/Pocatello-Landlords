using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{

    /*
     * Michael Sterner: Game class 1.2
     * This is the initial starting point for the game; eventually this class will be instantiated by an exterior function.
     * Initially, the class will implement a tic-tack-toe game, but it's future purpose will be to execute a playable
     * Monopoly game.
     * 
     * Please describe changes made here; along with your name, date, and version:
     * Renamed variables and added public properties for use by the test harness - Rex Christensen - 27JAN2019 - v1
     * Instantiated a Board object and Players list - Rex Christensen - 27JAN2019 - v1
     * Changed makeNextPlayersTurn() to public for use in the test harness - 27JAN2019 - v1
     * Added a "Value" to each created property in the board to reflect what space it is on a tic tac toe board - Rex Christensen - 27JAN2019 - v1
     * Moved player list construction to the inheriting class, commented out a couple of unused lines. - M.S. 30JAN2019 - v1.2
     * Added variables for the host player, number of players, and maximum number of players. Added creation of host player in constructor - Rex 27MAR19
     * 
     */
    class Game
    {
        Board _GameBoard;
        List<Player> players;
        int lastPlayerID = -1;
        Player currentPlayer;
        private GameStates gameState;
        Player myPlayer;
        protected int numberOfPlayers;
        protected int maxNumPlayers;

        public Board GameBoard { get { return _GameBoard; } }
        public Player CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }
        public List<Player> Players { get { return players; } set { players = value; } }
        public GameStates GameState { get; set; }
        public Player MyPlayer { get; set; }

        public Game()
        {
            gameState = GameStates.Running;
            _GameBoard = new Board();
            Players = new List<Player>();
            Player.LastAssignedID = 0;
            // Creat a new player for the host
            myPlayer = new Player();
        }

        public Game(List<Space> spaces)
        {
            gameState = GameStates.Running;
            _GameBoard = new Board(spaces);
            Players = new List<Player>();
            Player.LastAssignedID = 0;
        }

        public Player getPlayerById(int id)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].PlayerID == id)
                {
                    return players[i];
                }
            }
            return null;
        }

        public virtual void handleTurn(int spaceIndex)
        {
            //default implemntation
            //if not needed we can make this abstract
        }

        public void makeNextPlayersTurn()
        {
            lastPlayerID = currentPlayer.PlayerID;
            if (currentPlayer.PlayerID >= Players.Count - 1)
            {
                currentPlayer = Players[0];
            }
            else
            {
                currentPlayer = Players[currentPlayer.PlayerID + 1]; // note that the playerID's are stored counting from 0
            }
            if (currentPlayer.Eliminated)
            {
                makeNextPlayersTurn();
            }
        }



        public void MovePlayer(Player plyr, int moveCount)
        {
            Space initial = plyr.CurrentSpace;
            while (moveCount != 0)
            {
                /// Tyler Arnet: Added to skip the Prison Space. 4/17/2019
                int temp = _GameBoard.Spaces.IndexOf(plyr.CurrentSpace);
                if (temp == 10) {
                    moveCount++;
                }
                
                if(temp < _GameBoard.Spaces.Count-1)
                // R.C. Chaged to add Ellipse object instead of .png image - 17 APR 2019
                {
                    plyr.CurrentSpace = _GameBoard.Spaces.ElementAt(temp+1);
                    _GameBoard.Spaces.ElementAt(temp).PlayerAreaStackPanel.Children.Remove(plyr.PlayerCircle);
                    // M.S. PlayerAreaStackPanel.Clear() was switched to this so that other pieces wouldn't disappear.
                    _GameBoard.Spaces.ElementAt(temp + 1).PlayerAreaStackPanel.Children.Add(plyr.PlayerCircle);
                }
                else
                {
                    plyr.CurrentSpace = _GameBoard.Spaces.ElementAt(0);
                    _GameBoard.Spaces.ElementAt(temp).PlayerAreaStackPanel.Children.Remove(plyr.PlayerCircle);
                    _GameBoard.Spaces.ElementAt(0).PlayerAreaStackPanel.Children.Add(plyr.PlayerCircle);
                }
                
                moveCount--;
            }
        }



        #region Display Manager Calls
        /// <summary>
        /// Call from Display Manager when player is to toll the dice
        /// </summary>
        public Tuple<int, int> InitateDiceRoll()
        {
            // Update the game board to advance the player  by the specified number of places
            Tuple<int, int> dice = GetDiceValues();

            currentPlayer.Position += dice.Item1 + dice.Item2;

            return dice;
        }

        /// <summary>
        /// Fernando Munoz
        /// March 9th, 2019
        /// 
        /// </summary>
        /// <returns>A pair of ints between 1 and 6 representing the dice roll</returns>
        private Tuple<int, int> GetDiceValues()
        {
            Random r = new Random();
            Tuple<int, int> dice;

            dice = new Tuple<int, int>(r.Next(1, 7), r.Next(1, 7));

            return dice;
        }



        #endregion


    }
}

