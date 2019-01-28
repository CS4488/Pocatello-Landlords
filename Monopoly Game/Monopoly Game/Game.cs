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
     * 
     * 
     */
    static class Game
    {
        static Board board;
        static List<Player> players = new List<Player>();
        static int lastPlayerID = -1;
        static Player currentPlayer;
        static private bool gameOver;

        internal static List<Player> Players { get => players; set => players = value; }
        internal static Player CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        //public Game()
        //{
        //    gameOver = false;
        //    if (this is TicTacToe)
        //        for (int i = 0; i < 9; i++)
        //            board.spaces.AddLast(new Property());// For tictactoe, owner is a needed variable, so type property is used
        //    currentPlayer = new Player(0);
        //    players.Add(currentPlayer);
        //    currentPlayer = new Player(1);
        //    players.Add(currentPlayer);
        //    currentPlayer = players[0];
        //}
        public static void startGame()
        {
            int playerCount = 3;
            for(int i = 0; i < playerCount; i++)
            {
                Player player = new Player(i);
                Players.Add(player);
            }
            CurrentPlayer = Players[0];
        }

            
        public static void playGame()
        {
            while (!gameOver)
            {
                CurrentPlayer.takeTurn();
                makeNextPlayersTurn();
                if (CurrentPlayer.playerID == lastPlayerID)
                    gameOver = true; //effectively if there are no other players then end game.
            }
        }
        public static void makeNextPlayersTurn()
        {
            lastPlayerID = CurrentPlayer.playerID;
            if (CurrentPlayer.playerID >= Players.Count - 1)
            {
                CurrentPlayer = Players[0];
            }
            else
            {
                CurrentPlayer = Players[CurrentPlayer.playerID + 1]; // note that the playerID's are stored counting from 0
            }
            if (CurrentPlayer.eliminated)
            {
                makeNextPlayersTurn();
            }
        }
    }
}
