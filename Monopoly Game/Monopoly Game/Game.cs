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
     * Pay rent check - KW 
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

        public Player GetNextPlayer(Player current)
        {
            if(Players.IndexOf(current) == Players.Count-1)
            {
                if (Players[0].Eliminated)
                {
                    return GetNextPlayer(Players[0]);
                }
                return Players[0];
            }
            else
            {
                if(Players[Players.IndexOf(current) + 1].Eliminated)
                {
                    return GetNextPlayer(Players[Players.IndexOf(current) + 1]);
                }
                return Players[Players.IndexOf(current) + 1];
            }
        }


        public void makeNextPlayersTurn()
        {
            if (!this.CurrentPlayer.HasRolled) return;
            lastPlayerID = currentPlayer.PlayerID;
            if (currentPlayer.PlayerID >= Players.Count - 1)
            {
                currentPlayer = Players[0];
            }
            else
            {
                currentPlayer = Players[currentPlayer.PlayerID + 1];
            }
            if (currentPlayer.Eliminated)
            {
                makeNextPlayersTurn();
            }
        }

        public void MovePlayer(Player plyr, int moveCount)
        {
            while (moveCount != 0)
            {
                MovePlayerToSpace(plyr, GameBoard.GetNextPlayableSpace(plyr.CurrentSpace));
                moveCount--;
            }
            CheckSpaceForActions();
        }

        public void MovePlayerToSpace(Player plyr, Space toSpace)
        {
            Space initial = plyr.CurrentSpace;
            initial.PlayerAreaStackPanel.Children.Remove(plyr.PlayerCircle);
            toSpace.PlayerAreaStackPanel.Children.Add(plyr.PlayerCircle);
            plyr.CurrentSpace = toSpace;
        }

        public void CheckSpaceForActions()
        {
            if (GameEngine.Game.CurrentPlayer.CurrentSpace is Property)
            {
                Property landedOn = (Property)GameEngine.Game.CurrentPlayer.CurrentSpace;
                if (landedOn.OwnerPlayerID != -1 && landedOn.OwnerPlayerID != GameEngine.Game.CurrentPlayer.PlayerID)
                {
                    System.Windows.MessageBox.Show("Need to pay rent");
                }
            }
        }
        
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
    }
}

