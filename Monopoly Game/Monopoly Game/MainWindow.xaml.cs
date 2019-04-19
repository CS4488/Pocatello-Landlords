using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;
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
    * Kalen - Make monopoly main game - 15APR19
    */
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MiMonopoly_Click(object sender, RoutedEventArgs e)
        {
            LandlordsBoard lb = new LandlordsBoard();
            frm_Main.Content = lb;
            GameEngine.SetupAsClient(lb.AggregatedSpaceObjects);
        }

        // begin a new game
        private void MiNewGame_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void MiSaveGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Since we're not networking eventualy we can use the serialized objects to save and load games");
        }

        private void MiLoadGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Since we're not networking eventualy we can use the serialized objects to save and load games");
        }

        private void MiExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            return;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(Int32.TryParse(InputTextBox.Text, out int numOfPlayers)))
            {// M.S. (if the input cannot be parsed as an integer)
                MessageBox.Show("Please enter a valid number");
                return;
            }
            LandlordsBoard lb = new LandlordsBoard();
            frm_Main.Content = lb;
            GameEngine.SetupAsClient(lb.AggregatedSpaceObjects); // This required because this is where the game is created
            GameEngine.Setup(numOfPlayers, lb.SpacePlayerAreas, lb.AggregatedSpaceObjects); // M.S. Setup these many players on the LandlordsBoard UI
            InputBox.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
