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


        private List<Space> _AggregatedSpaceObjects = new List<Space>();


        private Player testPlayer;
        #endregion

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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel wp = _SpacePlayerAreas.ElementAt(0);
            if(wp.Children.Count == 0 && testPlayer == null)
            {
                GameEngine.Game.GameBoard.Spaces = _AggregatedSpaceObjects;
                testPlayer = new Player();
                testPlayer.CurrentSpace = _AggregatedSpaceObjects.ElementAt(0);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("/images/Token.png", UriKind.Relative));
                testPlayer.TokenImage = image;
                image.Height = image.Width = wp.Height / 2;
                wp.Children.Add(image);
            }
            else
            {
                GameEngine.Game.MovePlayer(testPlayer, 1);
            }
            
            
        }
    }

}
