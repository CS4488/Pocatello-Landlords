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
    class Game
    {
        Board board;            
        List<Player> players;
        int lastPlayerID = -1;
        Player currentPlayer;
        private bool gameOver;
        public Game()
        {
            gameOver = false;
            if (this is TicTacToe)
                for (int i = 0; i < 9; i++)
                    board.spaces.AddLast(new Property());// For tictactoe, owner is a needed variable, so type property is used
            currentPlayer = new Player(0);
            players.Add(currentPlayer);
            currentPlayer = new Player(1);
            players.Add(currentPlayer);
            currentPlayer = players[0];
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
        private void makeNextPlayersTurn()
        {
            lastPlayerID = currentPlayer.playerID;
           if (currentPlayer.playerID >= players.Count - 1)
                currentPlayer = players[0];
           else
                currentPlayer = players[currentPlayer.playerID + 1]; // note that the playerID's are stored counting from 0
           if (currentPlayer.eliminated)
                makeNextPlayersTurn();
        }
    }
}
