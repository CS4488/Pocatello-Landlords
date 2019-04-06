using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    /*
    * Rex Christesnsen: MainWindow.xaml.cs class 1.0
    * Kalen Williams - Refactoring display to DisplayManager
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Added a Tic Tac Toe board composed of 9 buttons that will show either X or O depending on what player clicked on them - R.C. - 27JAN19
    * Adjusted the event handlers for each button to reflect change from LinkedList to List data structure - R.C. - 29JAN19 - v1
    * M.S. Made the makeMove function more generic, so as to accept moves that are not dependent on player clicks... This was
    * done to make it possible for the computer player to input a move. M.S. - 30JAN2019
    * Rex - Added a Host Game menu option that creates and starts a Server object - 12MAR2019
    * Rex - Changed Host and Join Game Methods to create/join Monopoly games instead of Tic Tac Toe - 5Apr19
    * Rex - Added calls to Server and Client classes to host or join games - 5Apr19
    */
    public partial class MainWindow : Window
    {



        //TicTacToe game;
        Game game;
        DisplayManager dm;
        int numPlayers;
        Dictionary<Tuple<int, int>, int> gridToIndexMap = new Dictionary<Tuple<int, int>, int>();

        public int NumPlayers { get { return numPlayers; } set { numPlayers = value; } }

        public MainWindow()
        {
            InitializeComponent();
            ticTacToeArea.Visibility = Visibility.Hidden;
        }

        //handle all button clicks
        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int x = (int)btn.GetValue(Grid.RowProperty);
            int y = (int)btn.GetValue(Grid.ColumnProperty);

            Tuple<int, int> coords = Tuple.Create(x, y);

            int index = gridToIndexMap[coords];
            handleGame(index);
        }

        private void MiMonopoly_Click(object sender, RoutedEventArgs e)
        {
            LandlordsBoard lb = new LandlordsBoard();
            frm_Main.Content = lb;
            // ************* Tweak this to ask for Host or Join, or jus change those methods
            GameEngine.SetupAsClient(lb.AggregatedSpaceObjects);
        }

        // begin a new game
        private void MiNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.fillMap();
            game = new TicTacToe();
            this.dm = new DisplayManager(game, ticTacToeArea);
            dm.updateDisplay();
        }

        // Changed to host a Monopoly game, and not a TicTacToe game - R.C. 5APR19
        private void MiHostGame_Click(object sender, RoutedEventArgs e)
        {
            List<Space> spaces = new List<Space>();
            game = new Game(spaces);
            Server gameServer = new Server();
            gameServer.Connect();
            gameServer.CurrentGame = game;

            MessageBox.Show("Have players connect to IP address " + gameServer.IpAddress);
            // For testing and debugging only
            GameEngine.NumberOfPlayers = 2;
            numPlayers = 2;

            // This should be delayed until at least one person is connected
            while (gameServer.Clients.Count + 1 != numPlayers) // Added the plus one to account for the host
            { // *******************************************************************
                // This is just here to delay until the count is right
            }
            LandlordsBoard lb = new LandlordsBoard();
            frm_Main.Content = lb;
            //MiNewGame_Click(sender, e);
        }

        // Changed to join a Monopoly game - R.C. 5 APR19
        private void MiJoinGame_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Functionality coming soon!");
            IPAddressEntry address = new IPAddressEntry();
            address.ShowDialog();
            Client client = new Client();
            client.ConnectToServer();
            Thread.Sleep(500); // This allows time for the other thread to read the Game object sent to it from the server - R.C. 5APR19
            game = client.CurrentGame; // This is still null for some reason. Appears to be firing AC the thread to read it does
            if (game != null) {
                LandlordsBoard lb = new LandlordsBoard();
                frm_Main.Content = lb;
            }
        }

        private void MiObserveGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Functionality coming soon!");
        }

        private void MiExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            return;
        }

        //Dispatches game logic and display logic to proper classes
        private void handleGame(int indexClicked)
        {
            game.handleTurn(indexClicked);
            dm.updateDisplay();
        }

        private void fillMap()
        {
            //set up mapping
            //definitely a way to do this mathematically
            //but I wasn't sure how and this works
            // formula is:
            // x = index % col
            // y = index / col
            // if someone wants to reverse that
            if (gridToIndexMap.Count > 0)
            {
                return;
            }
            Tuple<int, int> coords = Tuple.Create(0, 0);
            gridToIndexMap.Add(coords, 0);

            coords = Tuple.Create(0, 1);
            gridToIndexMap.Add(coords, 1);

            coords = Tuple.Create(0, 2);
            gridToIndexMap.Add(coords, 2);

            coords = Tuple.Create(1, 0);
            gridToIndexMap.Add(coords, 3);

            coords = Tuple.Create(1, 1);
            gridToIndexMap.Add(coords, 4);

            coords = Tuple.Create(1, 2);
            gridToIndexMap.Add(coords, 5);

            coords = Tuple.Create(2, 0);
            gridToIndexMap.Add(coords, 6);

            coords = Tuple.Create(2, 1);
            gridToIndexMap.Add(coords, 7);

            coords = Tuple.Create(2, 2);
            gridToIndexMap.Add(coords, 8);
        }

    }
}
