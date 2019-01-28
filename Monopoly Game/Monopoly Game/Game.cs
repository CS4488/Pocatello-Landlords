using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{

    /*
     * Michael Sterner: Game class 1.0
     * This is the initial starting point for the game; eventually this class will be instantiated by an exterior function.
     * Initially, the class will implement a tic-tack-toe game, but it's future purpose will be to execute a playable
     * Monopoly game.
     * 
     * Please describe changes made here; along with your name, date, and version:
     * Renamed variables and added public properties for use by the test harness - Rex Christensen - 27JAN2019 - v1
     * Instantiated a Board object and Players list - Rex Christensen - 27JAN2019 - v1
     * Changed makeNextPlayersTurn() to public for use in the test harness - 27JAN2019 - v1
     * Added a "Value" to each created property in the board to reflect what space it is on a tic tac toe board - Rex Christensen - 27JAN2019 - v1
     * 
     */
    class Game
    {
        Board gameBoard;            
        List<Player> Players;
        int lastPlayerID = -1;
        Player currentPlayer;
        private bool gameOver;

        public Board GameBoard { get { return gameBoard; } }
        public Player CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }

        public Game()
        {
            gameOver = false;
            gameBoard = new Board();
            Players = new List<Player>();
            int playerCount = 2;
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player(i);
                Players.Add(player);
            }
            CurrentPlayer = Players[0];
        }
        public void playGame()
        {
            while (!gameOver)
            {
                currentPlayer.takeTurn();
                makeNextPlayersTurn();
                if (currentPlayer.playerID == lastPlayerID)
                    gameOver = true; //effectively if there are no other players then end game.
            }
        }
        public void makeNextPlayersTurn()
        {
            lastPlayerID = currentPlayer.playerID;
           if (currentPlayer.playerID >= Players.Count - 1)
                currentPlayer = Players[0];
           else
                currentPlayer = Players[currentPlayer.playerID + 1]; // note that the playerID's are stored counting from 0
           if (currentPlayer.eliminated)
                makeNextPlayersTurn();
        }

        public bool checkForTicTacToeWin() {
            bool win = false;
            // Check for horizontal wins
            
            // Check for verticle wins

            // Check for diagonal wins

            return win;
        }
    }
}
