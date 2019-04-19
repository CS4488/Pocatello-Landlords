﻿using System;
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
    /// Purpose: Creates and gets all the interactive UI elements
    /// Made by Fernando Munoz
    /// March 3rd, 2019
    /// 
    /// 
    /// XAML Naming Conventions:
    ///     Button (Space): btnSpace[number(0 indexed)]
    ///     Space Name: tbSpace[number(0 indexed)]Name
    ///     Space Cost: tbSpace[numbe(0 indexed)]Cost
    ///     Building StackPanel: stkPnlBldg[number(0 indexed)]
    ///     Player Space StackPanel: stkPnlPlyrs[number(0 indexed)]
    ///     
    /// M.S. Get method for WrapPanel _SpacePlayerAreas was added 4/16/19
    ///     Test method was changed to show players added to the GameEngine
    /// </summary>
    public partial class LandlordsBoard : Page
    {
        #region Private variables
        public const int SpaceCount = 41;
        private Button[] _SpaceButtons = new Button[SpaceCount];
        private TextBlock[] _SpaceCosts = new TextBlock[SpaceCount];
        private TextBlock[] _SpaceNames = new TextBlock[SpaceCount];
        private StackPanel[] _SpaceBuildings = new StackPanel[SpaceCount];
        private WrapPanel[] _SpacePlayerAreas = new WrapPanel[SpaceCount];

        private readonly int[] _PropertyNdxs = {1, 3, 5, 6, 8, 9, 12, 13, 14, 15, 16, 17,
                                    19, 20, 22, 24, 25, 26, 27, 28, 29, 30, 32,
                                    33, 35, 36, 38, 40};
        private readonly int[] _BuildableNdxs = {1, 3, 6, 8, 9, 12, 14, 15, 17,
                                    19, 20, 22, 24, 25, 27, 28, 30, 32, 33, 35, 38, 40};
        private readonly int[] _LootCrateNdxs = { 4, 18, 34 };
        private readonly int[] _OpportunityNdxs = { 7, 23, 37 };
        private readonly int[] _EventNdxs = { 0, 2, 31, 39, 21 };
        //private readonly int[] _EventNdxs = { 0, 31 };


        private List<Space> _AggregatedSpaceObjects = new List<Space>();


        //private Player testPlayer; // M.S. Test obsolete
        #endregion

        public WrapPanel[] SpacePlayerAreas // M.S. Added in order to access a UI "space" index from function Setup in GameEngine
        {
            get
            {
                return _SpacePlayerAreas;
            }
        }
        public List<Space> AggregatedSpaceObjects
        {
            get
            {
                return _AggregatedSpaceObjects;
            }
        }

        #region Constructors
        public LandlordsBoard()
        {
            InitializeComponent();
            InitializeGameBoard();
            FixMouseOverEffect();
            BuildSpaceObjects();
        }

        private void BuildSpaceObjects()
        {
            for (int i = 0; i < SpaceCount; i++)
            {
                Space temp;
                if (_SpaceCosts[i] != null)
                {
                    temp = new Property(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i], _SpaceBuildings[i], _SpaceCosts[i]);
                }
                else if (Array.Exists(_EventNdxs, x => x == i))
                {
                    temp = new Event(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i]);
                }
                else
                {
                    temp = new Space(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i]);
                }
                _AggregatedSpaceObjects.Add(temp);
            }
        }
        #endregion

        #region Properties
        //public List<Button> SpaceButtons
        //{
        //    get
        //    {
        //        return _SpaceButtons;
        //    }
        //}

        //public List<TextBlock> SpaceCosts
        //{
        //    get
        //    {
        //        return _SpaceCosts;
        //    }
        //}

        //public List<TextBlock> SpaceNames
        //{
        //    get
        //    {
        //        return _SpaceNames;
        //    }
        //}

        //public int[] PropertyNdxs
        //{
        //    get
        //    {
        //        return _PropertyNdxs;
        //    }
        //}

        //public int[] LootCrateNdxs
        //{
        //    get
        //    {
        //        return _LootCrateNdxs;
        //    }
        //}

        //public int[] OpportunityNdxs
        //{
        //    get
        //    {
        //        return _OpportunityNdxs;
        //    }
        //}
        #endregion

        #region Playable Space Methods

        /// <summary>
        /// Fernando Munoz 
        /// March 5th, 2019
        /// Updated March 12th to use generics and work for getting all types of UI elements
        ///
        /// Description: Sets the local field _Spaces to contain a list of all the playable spaces(which are of type Button)
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">List to add the UI element to</param>
        /// <param name="part1">First part of name to search</param>
        /// <param name="part2">Second part, which follows the number, of a UI element to search</param>
        private void GetUIElements<T>(T[] array, string part1, string part2)
        {
            for (int i = 0; i < SpaceCount; i++)
            {
                T temp = (T)this.FindName(part1 + i.ToString() + part2);

                if (temp != null)
                {
                    array[i] = (temp);
                }
            }
        }
        #endregion

        #region Internal Methods

        /// <summary>
        /// Sets each respective list to contain the UI elements found on the gameboard
        /// </summary>
        private void InitializeGameBoard()
        {
            GetUIElements(_SpaceButtons, "btnSpace", String.Empty);
            GetUIElements(_SpaceCosts, "tbSpace", "Cost");
            GetUIElements(_SpaceNames, "tbSpace", "Name");
            GetUIElements(_SpaceBuildings, "stkPnlBldg", String.Empty);
            GetUIElements(_SpacePlayerAreas, "stkPnlPlyrs", String.Empty);
        }

        // We need the opacity to be 0, but simply setting it from the XAML Design editor messes up the responsiveness 
        // Here we ensure the Z index is highest on the space button and that we have 0 aplha value for our background color
        // Setting it in this way fixes the responsiveness problem.
        private void FixMouseOverEffect()
        {
            foreach (Button b in _SpaceButtons)
            {
                Grid.SetZIndex(b, 10);
                b.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
        }
        #endregion

        // This is no longer used
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Tuple <int,int> dice = GameEngine.Game.InitateDiceRoll();
        //    GameEngine.Game.MovePlayer(GameEngine.Game.CurrentPlayer, dice.Item1 + dice.Item2);
        //    GameEngine.Game.makeNextPlayersTurn();
        //}

        /// <summary>
        /// R.C. 4/17/2019
        /// Gets the Dice roll and moves the player by that amount
        /// Based of of code written by Nando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRollDice_Click(object sender, RoutedEventArgs e) { // ** Add a check for doubles **
            if (!GameEngine.Game.CurrentPlayer.HasRolled) {
                Tuple<int, int> dice = GameEngine.Game.InitateDiceRoll();
                txtDice1.Text = dice.Item1.ToString();
                txtDice2.Text = dice.Item2.ToString();
                if (dice.Item1 != dice.Item2) GameEngine.Game.CurrentPlayer.HasRolled = true;
                else GameEngine.Game.makeNextPlayersTurn();
                GameEngine.Game.MovePlayer(GameEngine.Game.CurrentPlayer, dice.Item1 + dice.Item2);
                updateGUIElements();
            }
        }

        /// <summary>
        /// R.C. 4/17/2019
        /// Ends the current players turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEndTurn_Click(object sender, RoutedEventArgs e) {
            GameEngine.Game.makeNextPlayersTurn();
            GameEngine.Game.CurrentPlayer.HasRolled = false;
            updateGUIElements();
        }

        private void updateGUIElements() {
            // *** This is what I'm planning on using to update things like the $$ and properties boxes. This could already be done somewhere else though 
            // Get the player's $$
            txtMoney.Text = "$"+GameEngine.Game.CurrentPlayer.CurrentFunds.ToString();
            // Get the player's properties

            // update the action button
            if (GameEngine.Game.CurrentPlayer.CurrentSpace.GetType() == typeof(Property)) {
                Property p = (Property)GameEngine.Game.CurrentPlayer.CurrentSpace;
                if (p.OwnerPlayerID == -1) {
                    imgActionImage.Source = new BitmapImage(new Uri("images/Buy.png", UriKind.RelativeOrAbsolute));
                } else {
                    imgActionImage.Source = new BitmapImage(new Uri("images/PayRent.png", UriKind.RelativeOrAbsolute));
                }
            } else if (GameEngine.Game.CurrentPlayer.CurrentSpace.GetType() == typeof(Event)) {
                imgActionImage.Source = new BitmapImage(new Uri("images/DrawCard.png", UriKind.RelativeOrAbsolute));
            } else {
                imgActionImage.Source = new BitmapImage(new Uri("images/PayTax.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void BtnAction_Click(object sender, RoutedEventArgs e) {

        }
    }

}
