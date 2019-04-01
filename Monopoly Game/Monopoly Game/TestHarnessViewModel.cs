using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game {
    public static class TestHarnessViewModel {
        static string currentPlayer;
        static string numPlayers;
        static string state;
        static string myPlayer;
        static string status;

        public static event EventHandler StatusChanged;
        public static event EventHandler CurrentPlayerChanged;
        public static event EventHandler NumPlayersChanged;
        public static event EventHandler StateChanged;
        public static event EventHandler MyPlayerChanged;

        public static string CurrentPlayer {
            get { return currentPlayer; }
            set {
                currentPlayer = value;
                if (CurrentPlayerChanged != null) {
                    CurrentPlayerChanged(null, EventArgs.Empty);
                }
            }
        }

        public static string NumPlayers {
            get { return numPlayers; }
            set {
                numPlayers = value;
                if (NumPlayersChanged != null) {
                    NumPlayersChanged(null, EventArgs.Empty);
                }
            }
        }

        public static string State {
            get { return state; }
            set {
                state = value;
                if (StateChanged != null) {
                    StateChanged(null, EventArgs.Empty);
                }
            }
        }

        public static string MyPlayer {
            get { return myPlayer; }
            set {
                myPlayer = value;
                if (MyPlayerChanged != null) {
                    MyPlayerChanged(null, EventArgs.Empty);
                }
            }
        }

        public static string Status { 
            get { return status; }  
            set {
                status = value;
                if (StatusChanged != null) {
                    StatusChanged(null, EventArgs.Empty);
                }
            }
        }

    }
}
