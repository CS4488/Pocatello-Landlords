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
    //TODO: The following is a list of methods that the Landlords game should be able to handle. 
    //      We should keep in mind that everything the gameBoard class should be responsible for is
    //      display logic.
    //
    /*  There will be more as the game is developed, and we may want to change around the way things are organized
     *  This list is not exhaustive...
     *  
     *  Gameboard Update Methods
     *       1. Move game peice (int player#, int numberSpaces), (int player#, Button destination)
     *       2. Display dice roll value (int rollValue)
     *       3. Update player properties(List properties)
     *       4. Update opponent properties( List<Pair<Player, List<Properties>>>, or something like this)
     *       5. Update player cards
     *       6. Display Endgame Gamestate (You won, You lost, Draw... and show message accordingly)
     *       7. Update current player's turn
     *       8. Show other player actions (dice rolls, properties (bought, sold, etc), cards drawn...)
     *  
     *  Player Actions
     *      1. Buy property
     *      2. Draw card
     *      3. Use card
     *      4. Build on property
     *      5. Roll dice
     *      6. 
     */



    /// <summary>
    /// Interaction logic for LandlordsBoard.xaml
    /// Made by Fernando Munoz
    /// March 3rd, 2019
    /// </summary>
    public partial class LandlordsBoard : Page
    {

        private List<Button> _Spaces = new List<Button>();

        public LandlordsBoard()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        public List<Button> Spaces
        {
            get
            {
                return _Spaces;
            }
        }

        private void InitializeGameBoard()
        {
            getAllSpaces();
        }

        #region Playable Space Methods

        /*
         * Fernando Munoz 
         * March 5th, 2019
         * 
         * Description: Sets the local field _Spaces to contain a list of all the playable spaces (which are of type Button)
         */
        private void getAllSpaces()
        {
            for (int i = 0; i < 40; i++)
            {
                Button buttonFound = (Button)this.FindName("btnSpace" + i.ToString());
                _Spaces.Add(buttonFound);
            }
        }
        #endregion
    }

}
