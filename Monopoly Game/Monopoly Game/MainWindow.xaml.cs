using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    */
    public partial class MainWindow : Window
    {
        TicTacToe game;
        DisplayManager dm;

        Dictionary<Tuple<int, int>, int> gridToIndexMap = new Dictionary<Tuple<int, int>, int>();

        public MainWindow()
        {
            InitializeComponent();
            playArea.Visibility = Visibility.Hidden;
            playArea.IsEnabled = false;
            fillMap();

            LandlordsBoard thing = new LandlordsBoard();
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

        // begin a new game
        private void MiNewGame_Click(object sender, RoutedEventArgs e) {
            game = new TicTacToe();
            this.dm = new DisplayManager(game, playArea);
            dm.updateDisplay();
        }

        private void MiJoinGame_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Functionality coming soon!");
        }

        private void MiObserveGame_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Functionality coming soon!");
        }

        private void MiExit_Click(object sender, RoutedEventArgs e) {
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
