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
    /// Naming Conventions:
    ///     Button (Space): btnSpace[number(0 indexed)]
    ///     Space Name: tbSpace[number(0 indexed)]Name
    ///     Space Cost: tbSpace[numbe(0 indexed)]Cost
    /// 
    /// </summary>
    public partial class LandlordsBoard : Page
    {
        #region Private variables
        private List<Button> _Spaces = new List<Button>();
        private List<TextBlock> _SpaceCosts = new List<TextBlock>();
        private List<TextBlock> _SpaceNames = new List<TextBlock>();

        private readonly byte[] _PropertyNdxs = {1, 3, 5, 6, 8, 9, 12, 13, 14, 15, 16, 17,
                                    19, 20, 22, 24, 25, 26, 27, 28, 29, 30, 32,
                                    33, 35, 36, 38, 40};
        private readonly byte[] _LootCrateNdxs = { 4, 18, 34 };
        private readonly byte[] _OpportunityNdxs = { 7, 23, 37 };
        private readonly byte[] _EventNdxs = { 0, 2, 31, 39, 21 };
        #endregion

        #region Constructors
        public LandlordsBoard()
        {
            InitializeComponent();
            InitializeGameBoard();
        }
        #endregion

        #region Properties
        public List<Button> Spaces
        {
            get
            {
                return _Spaces;
            }
        }

        public List<TextBlock> SpaceCosts
        {
            get
            {
                return _SpaceCosts;
            }
        }

        public List<TextBlock> SpaceNames
        {
            get
            {
                return _SpaceNames;
            }
        }

        public byte[] PropertyNdxs
        {
            get
            {
                return _PropertyNdxs;
            }
        }

        public byte[] LootCrateNdxs
        {
            get
            {
                return _LootCrateNdxs;
            }
        }

        public byte[] OpportunityNdxs
        {
            get
            {
                return _OpportunityNdxs;
            }
        }
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
        private void GetUIElements<T> (List<T> list, string part1, string part2)
        {
            for (int i = 0; i < 41; i++)
            {
                T temp = (T)this.FindName(part1 + i.ToString() + part2);

                if (temp != null)
                {
                    list.Add(temp);
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
            GetUIElements(_Spaces, "btnSpace", String.Empty);
            GetUIElements(_SpaceCosts, "tbSpace", "Cost");
            GetUIElements(_SpaceNames, "tbSpace", "Name");
        }
        #endregion
    }

}
