﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Created by Fernando Munoz
/// March 15th, 2019
/// 
/// Purpose: Handles and relays all logic between Game, Network and Display
/// </summary>
namespace Monopoly_Game
{
    static class GameEngine
    {

        // We will need a thread for each of the objects. I believe the network is by design, per Rex, threaded already.

        private static DisplayManager _DM;
        private static Game _Game;
        //private static Network _Network;
        private static int _LocalPlayerID;

        public static DisplayManager DM
        {
            get { return _DM; }
            set { _DM = value; }
        }

        public static Game Game
        {
            get { return _Game; }
            set { _Game = value; }
        }

        //public static Network Network
        //{
        //    get { return _DM; }
        //    set { _DM = value; }
        //}

        public static int LocalPlayerID
        {
            get { return _LocalPlayerID; }
            set { _LocalPlayerID = value; }
        }

        public static void CheckIfLocalTurn()
        {
            if (_Game.CurrentPlayer.PlayerID == _LocalPlayerID)
            {
                // It is currently the local player's turn, do stuff
            }
        }


        /// <summary>
        /// This will grab an assigned ID from the network
        /// </summary>
        public static void Setup()
        {
            // ----------- Psuedo code ----------------
            //  First, setup the local player's ID
            /*
             * while(network.currentplayerid == null)
             * {
             *      thread.sleep(500);
             *      this.currentPlayerID = network.currentPlayerID
             * }
             * 
             * Now, lets do some stuff. If the player ID is assigned, the game object should be set
             * 
             * _Game = _Network
             * 
             */
        }


    }
}