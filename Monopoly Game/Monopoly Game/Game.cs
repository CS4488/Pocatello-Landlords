using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
     * Client was added to the game. Games can still work atonomously from the Server but it is always important to have a disconnect method in the handleTurn function. - M.S. 2/27/19
     * 
     */
    class Game
    {
        Board gameBoard;
        List<Player> players;
        int lastPlayerID = -1;
        Player currentPlayer;
        public GameStates gameState;
        public Client client = new Client();
        public Thread listenThread;
        public Board GameBoard { get { return gameBoard; } }
        public Player CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }
        public List<Player> Players { get { return players; } set { players = value; } }
        public GameStates GameState {get; set;}
    


        public Game()
        {
            gameState = GameStates.Running;
            gameBoard = new Board();
            Players = new List<Player>();
            Player.LastAssignedID = 0;
            // M.S. Client is a relevant part of all game types
            client.StartClient(this);
            ThreadStart listenThreadStart = new ThreadStart(client.ReadMessages);
            listenThread = new Thread(listenThreadStart);
            listenThread.Start();
        }

        public Player getPlayerById(int id)
        {
            for(int i = 0; i < players.Count; i++)
            {
                if(players[i].PlayerID == id)
                {
                    return players[i];
                }
            }
            return null;
        }

        public virtual void handleTurn(int spaceIndex)
        {
            if (GameState == GameStates.GameOver)
            {
                client.Disconnect(); //M.S. added for proper thread handling 2/26/19
                return;
            }
            //default implemntation
            //if not needed we can make this abstract
        }

        public void makeNextPlayersTurn()
        {
           lastPlayerID = currentPlayer.PlayerID;
           if (currentPlayer.PlayerID >= Players.Count - 1) {
                currentPlayer = Players[0];
           }
           else {
                currentPlayer = Players[currentPlayer.PlayerID + 1]; // note that the playerID's are stored counting from 0
           }
           if (currentPlayer.Eliminated) {
                makeNextPlayersTurn();
           }
        }

        //M.S.
        
        
    }
}
