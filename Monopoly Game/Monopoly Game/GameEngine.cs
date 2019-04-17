﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

/// <summary>
/// Created by Fernando Munoz
/// March 15th, 2019
/// 
/// Purpose: Handles and relays all logic between Game, Network and Display
/// 
/// M.S. The Setup function is now used to "put" player Tokens on the UI 4/16/19
/// R.C. Setup changed to add Ellipse objects instead of images. 4/17/2019
/// </summary>
namespace Monopoly_Game
{
    static class GameEngine
    {

        // We will need a thread for each of the objects. I believe the network is by design, per Rex, threaded already.

        private static DisplayManager _DM;
        private static Game _Game;
        private static Server _Server;
        private static Client _Client;

        private static int _LocalPlayerID;
        private static int _NumberOfPlayers;


        public static void InitializeFromGame()
        {

        }
        /// <summary>
        /// The network will either be of type Server or Client.
        /// </summary>
        public static void SetupAsServer(List<Space> boardSpaces)
        {
            _Game = new Game(boardSpaces);
            _Server = new Server();
            _Server.Connect();
            while (_Server.Clients.Count != _NumberOfPlayers)
            { // *******************************************************************
                // This is just here to delay until the count is right
            }
            // NewGame(sender, e);

        }

        public static void SetupAsClient(List<Space> boardSpaces)
        {
            _Game = new Game(boardSpaces);
        }




        public static int NumberOfPlayers
        {
            get { return _NumberOfPlayers; }
            set { _NumberOfPlayers = value; }
        }

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
        public static void Setup(int numOfPlayers, WrapPanel[] lb, List<Space> AggregatedSpaceObjects)
        {
            for (; numOfPlayers > 0; numOfPlayers--) GameEngine.Game.Players.Add(new Player());
            WrapPanel wp = lb.ElementAt(0); //M.S. Indicates that the players will be set to the first space on the display.
            foreach (Player player in Game.Players)// The following code was derived from Nando's test methods 4/16/19
            {
                Game.GameBoard.Spaces = AggregatedSpaceObjects;
                player.CurrentSpace = AggregatedSpaceObjects.ElementAt(0);
                player.PlayerCircle.Height = player.PlayerCircle.Width = wp.Height / 2;
                wp.Children.Add(player.PlayerCircle);
            }
            Game.CurrentPlayer = Game.Players[0];
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

        private static void NewGame(object sender, System.Windows.RoutedEventArgs e)
        {
            _Game = new Game();
            //_DM = new DisplayManager(_Game, playArea);
            _DM.updateDisplay();
        }


    }
}