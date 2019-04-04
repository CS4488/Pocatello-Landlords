using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    /*
     * Michael Sterner: CompPlayer class 1.0
     * 30JAN2019
     * This class is meant to handle the thought process of the computer player. This will depend on the game type, so it will likely
     * instantiate a strategy.
     * 
     * M.S. 1/30/19 I really want to make this generic but don't want to get too far ahead of myself. The current code only handles tic
     * tac toe on the local level.
     * 
     * Please describe changes made here; along with your name, date, and version:
     */
    class CompPlayer : Player
    {
        private Property[] board;
        public CompPlayer()
        {
            base.PlayerID = Player.lastAssignedId;
            Player.lastAssignedId++;

        }
        public CompPlayer(int inputID)
        {
            base.PlayerID = inputID;
        }
        private int getMove(Board inputBoard)
        {
            board = inputBoard.Spaces.Cast<Property>().ToArray();
            if (WinningMove() != -1) return WinningMove();
            if (TakeCenter() != -1) return TakeCenter();
            if (TakeCorner() != -1) return TakeCorner();
            if (TakeSide() != -1) return TakeSide();
            return -1;
        }

        public override bool takeTurn(int spaceIndex, Game game)
        {
            bool validTurn = false;
            int compMove = this.getMove(game.GameBoard);
            if (compMove == -1)
            {
                return validTurn;
            }
            Property toTake = (Property)game.GameBoard.Spaces[compMove];
            toTake.OwnerPlayerID = game.CurrentPlayer.PlayerID;
            validTurn = true;
            return validTurn;
        }

        /*
         * M.S.~ The algorythm for WinningMove is structured similarly to Fernando's Win Condition Check for tic tac toe.
         */
        private int WinningMove()
        {
            // Horizontal checks
            for (int i = 0; i < 8; i += 3)
            {
                if (board[i].OwnerPlayerID == board[i + 1].OwnerPlayerID && board[i].OwnerPlayerID != -1 && board[i + 2].OwnerPlayerID == -1)
                    return i + 2;
                if (board[i].OwnerPlayerID == board[i + 2].OwnerPlayerID && board[i].OwnerPlayerID != -1 && board[i + 1].OwnerPlayerID == -1)
                    return i + 1;
                if (board[i + 1].OwnerPlayerID == board[i + 2].OwnerPlayerID && board[i + 1].OwnerPlayerID != -1 && board[i].OwnerPlayerID == -1)
                    return i;
            }
            // Vertical checks
            for (int i = 0; i < 3; i++)
            {
                if (board[i].OwnerPlayerID == board[i + 3].OwnerPlayerID && board[i].OwnerPlayerID != -1 && board[i + 6].OwnerPlayerID == -1)
                    return i + 6;
                if (board[i].OwnerPlayerID == board[i + 6].OwnerPlayerID && board[i].OwnerPlayerID != -1 && board[i + 3].OwnerPlayerID == -1)
                    return i + 3;
                if (board[i + 3].OwnerPlayerID == board[i + 6].OwnerPlayerID && board[i + 3].OwnerPlayerID != -1 && board[i].OwnerPlayerID == -1)
                    return i;
            }
            // Diagonal checks
            if (board[0].OwnerPlayerID == board[4].OwnerPlayerID && board[0].OwnerPlayerID != -1 && board[8].OwnerPlayerID == -1)
                return 8;
            if (board[0].OwnerPlayerID == board[8].OwnerPlayerID && board[0].OwnerPlayerID != -1 && board[4].OwnerPlayerID == -1)
                return 4;
            if (board[4].OwnerPlayerID == board[8].OwnerPlayerID && board[4].OwnerPlayerID != -1 && board[0].OwnerPlayerID == -1)
                return 0;

            if (board[2].OwnerPlayerID == board[4].OwnerPlayerID && board[2].OwnerPlayerID != -1 && board[6].OwnerPlayerID == -1)
                return 6;
            if (board[2].OwnerPlayerID == board[6].OwnerPlayerID && board[2].OwnerPlayerID != -1 && board[4].OwnerPlayerID == -1)
                return 4;
            if (board[4].OwnerPlayerID == board[6].OwnerPlayerID && board[4].OwnerPlayerID != -1 && board[2].OwnerPlayerID == -1)
                return 2;

            return -1;
        }
        private int TakeCorner()
        {
            if (board[0].OwnerPlayerID == -1 && board[0].OwnerPlayerID == -1) return 0;
            if (board[2].OwnerPlayerID == -1 && board[2].OwnerPlayerID == -1) return 2;
            if (board[6].OwnerPlayerID == -1 && board[6].OwnerPlayerID == -1) return 6;
            if (board[8].OwnerPlayerID == -1 && board[8].OwnerPlayerID == -1) return 8;
            return -1;
        }
        private int TakeCenter()
        {
            if (board[4].OwnerPlayerID == -1 && board[4].OwnerPlayerID == -1) return 4;
            return -1;
        }
        private int TakeSide()
        {
            if (board[1].OwnerPlayerID == -1 && board[1].OwnerPlayerID == -1) return 1;
            if (board[3].OwnerPlayerID == -1 && board[3].OwnerPlayerID == -1) return 3;
            if (board[5].OwnerPlayerID == -1 && board[5].OwnerPlayerID == -1) return 5;
            if (board[7].OwnerPlayerID == -1 && board[7].OwnerPlayerID == -1) return 7;
            return -1;
        }
    }
}