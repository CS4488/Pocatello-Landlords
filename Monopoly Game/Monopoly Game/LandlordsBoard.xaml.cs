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
    ///     
    /// M.S. Get method for WrapPanel _SpacePlayerAreas was added 4/16/19
    ///     Test method was changed to show players added to the GameEngine
    ///     
    /// KW Purchase properties
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
        private readonly int[] _EventNdxs = { 0, 2, 4, 7, 18, 21, 23, 31, 34, 37, 39, 41 };
        //private readonly int[] _EventNdxs = { 0, 31 };


        private List<Space> _AggregatedSpaceObjects = new List<Space>();

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
            SetSpaceButtonClicks();
        }

        #region Playable Space Methods

        private void BuildSpaceObjects()
        {
            for (int i = 0; i < SpaceCount; i++)
            {
                Space temp;
                if (Array.Exists(_BuildableNdxs, x => x == i))
                {
                    temp = new BuildableProperty(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i], _SpaceBuildings[i], _SpaceCosts[i]);
                    BuildableProperty prop = (BuildableProperty)temp;
                    prop.Value = getPropertyValue(i);

                }
                else if(Array.Exists(_PropertyNdxs, x => x == i))
                {
                    temp = new Property(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i], getPropertyValue(i));
                }
                else if (Array.Exists(_EventNdxs, x => x == i))
                {
                    temp = new Event(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i]);
                }
                else if (_SpaceCosts[i] != null)
                {
                    temp = new Property(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i], _SpaceBuildings[i], _SpaceCosts[i]);
                }
                else
                {
                    temp = new Space(i.ToString(), _SpaceNames[i], _SpaceButtons[i], _SpacePlayerAreas[i]);
                    if(i == 11)
                    {
                        temp.Playable = false;
                    }
                }
                _AggregatedSpaceObjects.Add(temp);
            }
        }
        #endregion



        private int getPropertyValue(int i)
        {
            if (i == 1)
            {
                return 60;
            }
            if (i == 3)
            {
                return 60;
            }
            if (i == 5)
            {
                return 200;
            }
            if (i == 6)
            {
                return 100;
            }
            if (i == 8)
            {
                return 100;
            }
            if (i == 9)
            {
                return 120;
            }
            if (i == 12)
            {
                return 140;
            }
            if (i == 13)
            {
                return 200;
            }
            if (i == 14)
            {
                return 140;
            }
            if (i == 15)
            {
                return 160;
            }
            if(i == 16)
            {
                return 200;
            }
            if(i == 17)
            {
                return 180;
            }
            if(i == 19)
            {
                return 180;
            }
            if(i == 20)
            {
                return 200;
            }
            if(i == 22)
            {
                return 200;
            }
            if(i == 24)
            {
                return 220;
            }
            if(i == 25)
            {
                return 220;
            }
            if(i == 26)
            {
                return 200;
            }
            if(i == 27)
            {
                return 260;
            }
            if(i == 28)
            {
                return 260;
            }
            if(i == 29)
            {
                return 200;
            }
            if(i == 30)
            {
                return 280;
            }
            if(i == 32)
            {
                return 300;
            }
            if( i == 33)
            {
                return 300;
            }
            if(i == 35)
            {
                return 320;
            }
            if(i == 36)
            {
                return 200;
            }
            if(i == 38)
            {
                return 350;
            }
            if(i == 40)
            {
                return 400;
            }

            return -1;
        }


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

        private void SetSpaceButtonClicks()
        {
            foreach(Button b in _SpaceButtons)
            {
                b.Click += new RoutedEventHandler(ClickOnProperty);
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
                //Grid.SetZIndex(b, 10); M.S. Is this nessesary? It messes with the Border I put up.
                b.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
        }
        #endregion


        /// <summary>
        /// R.C. 4/17/2019
        /// Gets the Dice roll and moves the player by that amount
        /// Based off of code written by Nando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRollDice_Click(object sender, RoutedEventArgs e)
        { // ** Add a check for doubles **
            if (!GameEngine.Game.CurrentPlayer.HasRolled)
            {
                Tuple<int, int> dice = GameEngine.Game.InitateDiceRoll();
                txtDice1.Text = dice.Item1.ToString();
                txtDice2.Text = dice.Item2.ToString();
                if (dice.Item1 != dice.Item2) GameEngine.Game.CurrentPlayer.HasRolled = true;
                else GameEngine.Game.makeNextPlayersTurn();
                GameEngine.Game.MovePlayer(GameEngine.Game.CurrentPlayer, dice.Item1 + dice.Item2);
                EventName.Text = GameEngine.Game.CurrentPlayer.CurrentSpace.Name;
                updateGUIElements();
            }
        }

        /// <summary>
        /// R.C. 4/17/2019
        /// Ends the current players turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            if (GameEngine.Game.CurrentPlayer.HasRolled)
            {
                Player nextPlayer = GameEngine.Game.GetNextPlayer(GameEngine.Game.CurrentPlayer);
                SetPlayerInfoOnTurnNotification(nextPlayer.PlayerID + 1, nextPlayer.TokenColor);
                GameEngine.Game.makeNextPlayersTurn();
            }
            GameEngine.Game.CurrentPlayer.HasRolled = false;
            updateGUIElements();
        }

        private void updateGUIElements()
        {
            // *** This is what I'm planning on using to update things like the $$ and properties boxes. This could already be done somewhere else though 
            // Get the player's $$
            this.DisplayPlayerMoney();
            // Get the player's properties
            this.DisplayPropertyOwnerships();
            // update the action button
            if (GameEngine.Game.CurrentPlayer.CurrentSpace.GetType() == typeof(Property))
            {
                Property p = (Property)GameEngine.Game.CurrentPlayer.CurrentSpace;
                if (p.OwnerPlayerID == -1)
                {
                    imgActionImage.Source = new BitmapImage(new Uri("images/Buy.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    imgActionImage.Source = new BitmapImage(new Uri("images/PayRent.png", UriKind.RelativeOrAbsolute));
                }
            }
            else if (GameEngine.Game.CurrentPlayer.CurrentSpace.XAMLID == "0" || GameEngine.Game.CurrentPlayer.CurrentSpace.XAMLID == "21")
            {
                imgActionImage.Source = null;
            }
            else if (GameEngine.Game.CurrentPlayer.CurrentSpace.GetType() == typeof(Event))
            {
                imgActionImage.Source = new BitmapImage(new Uri("images/PayTax.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
                imgActionImage.Source = new BitmapImage(new Uri("images/DrawCard.png", UriKind.RelativeOrAbsolute));
            }
        }
       
        /// <summary>
        /// Handle action button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {//M.S. Modified to display a border within a grid instead of a window.
            Player currentPlayer = GameEngine.Game.CurrentPlayer;
            EventDisplay.Visibility = ContinueButton.Visibility = CancelButton.Visibility = System.Windows.Visibility.Visible;
            if (currentPlayer.CurrentSpace is Property)
            {
                Property property = (Property)currentPlayer.CurrentSpace;
                if (property.OwnerPlayerID == currentPlayer.PlayerID)
                {
                    int buildCost = ((BuildableProperty)property).BuildCost();
                    if(buildCost == -1)
                    {
                        ContinueButton.Visibility = System.Windows.Visibility.Collapsed;
                        EventDescription.Text = "You already have a hotel and cannot build any further";
                    }
                    else
                    {
                        EventDescription.Text = "This property is yours, would you like to build on it for " + buildCost.ToString() + " ?";
                    }
                    
                    ContinueButton.Content = "Build";
                    CancelButton.Content = "Cancel";
                }
                else if (property.OwnerPlayerID != -1)
                {
                    EventDescription.Text = "The property Currently Belongs to Player:" + property.OwnerPlayerID.ToString();
                    ContinueButton.Content = "Pay";
                    CancelButton.Content = "Haggle";
                }
                else
                {
                    string propertyCost = "$" + property.Value.ToString();
                    EventDescription.Text = "This property is not currently owned. You may buy it for " + propertyCost + " or leave it alone.";
                    ContinueButton.Content = "Buy";
                    CancelButton.Content = "Cancel";
                }
            }
            else if (currentPlayer.CurrentSpace is Event)
            {
                EventDescription.Text = "This is an event card!";
                ContinueButton.Content = "Continue";
                CancelButton.Content = "";
                CancelButton.Visibility = System.Windows.Visibility.Collapsed; // Make sure to make it reappear after a click
            }
        }
        //M.S. 4/25/19 This is the button within the Eventdisplay that will allow the player to interact with the space.
        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Player currentPlayer = GameEngine.Game.CurrentPlayer;
            EventDisplay.Visibility = EventDisplay.Visibility = System.Windows.Visibility.Visible;
            if (currentPlayer.CurrentSpace is Property)
            {
                Property property = (Property)currentPlayer.CurrentSpace;
                if (property.OwnerPlayerID == currentPlayer.PlayerID)
                {
                    int buildCost = ((BuildableProperty)property).BuildCost();
                    if (currentPlayer.CurrentFunds >= buildCost)
                    {
                        currentPlayer.CurrentFunds -= buildCost;
                        ((BuildableProperty)property).Build();
                        DisplayPlayerMoney();
                    }
                    else
                    {
                        MessageBox.Show("Insufficient funds!");
                    }
                }
                else if (property.OwnerPlayerID == -1)
                {
                    GameEngine.Game.CurrentPlayer.purchaseProperty(ref property);
                    DisplayPropertyOwnerships();
                    DisplayPlayerMoney();
                    EventDisplay.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    //M.S. Current player pays the current owner of the property
                }
            }
            else if (currentPlayer.CurrentSpace is Event)
            {
                //M.S. Event stuff happens... is there a method for this?
                CancelButton.Visibility = System.Windows.Visibility.Visible;// Otherwise the button stays invisible.
                EventDisplay.Visibility = System.Windows.Visibility.Collapsed;
            }
            EventDisplay.Visibility = System.Windows.Visibility.Collapsed;
        }
        // M.S. This button will cancel the players interaction with the space.
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            EventDisplay.Visibility = System.Windows.Visibility.Collapsed;
        }
        public void DisplayPlayerMoney()
        {
            txtMoney.Text = "$" + GameEngine.Game.CurrentPlayer.CurrentFunds.ToString();
        }

        /// <summary>
        /// Updates the Opponent Properties display
        /// </summary>
        public void DisplayPropertyOwnerships()
        {
            stkPropertiesOwned.Children.Clear();
            spOponentProperties.Children.Clear();
            for(int i = 0; i < GameEngine.Game.CurrentPlayer.getOwnedSpaces().Count; i++)
            {
                Property property = (Property)GameEngine.Game.CurrentPlayer.getOwnedSpaces()[i];
                Player owner = GameEngine.Game.getPlayerById(property.OwnerPlayerID);
                TextBlock tb = new TextBlock();
                SolidColorBrush fontColor = new SolidColorBrush(owner.TokenColor);
                tb.Text = property.OwnerPlayerID + ": " + property.Name;
                tb.Foreground = fontColor;
                stkPropertiesOwned.Children.Add(tb);                  
            }
            List<Player> players = GameEngine.Game.Players;
            for(int i = 0; i < players.Count; i++)
            {
                if(players[i].PlayerID != GameEngine.Game.CurrentPlayer.PlayerID)
                {
                    List<Space> properties = players[i].getOwnedSpaces();
                    for(int j = 0; j < properties.Count; j++)
                    {
                        Property property = (Property)properties[j];
                        Player owner = players[i];
                        TextBlock tb = new TextBlock();
                        SolidColorBrush fontColor = new SolidColorBrush(owner.TokenColor);
                        tb.Text = property.OwnerPlayerID + ": " + property.Name;
                        tb.Foreground = fontColor;
                        spOponentProperties.Children.Add(tb);                  
                    }
                }
            }
        }

        private void MiExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            return;
        }

        private void MiUseCard_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming Soon!");
        }

        private void SetPlayerInfoOnTurnNotification(int playerNumber, Color background)
        {
            PlayerNumber.Content = playerNumber.ToString() + "'s";
            PlayerTurnBackground.Fill = new SolidColorBrush(background);
            PlayerColorBoard.BorderBrush = new SolidColorBrush(background);
        }

        public void ClickOnProperty(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int ID = 0;
            Int32.TryParse(b.Name.Replace("btnSpace", ""), out ID);

            if(GameEngine.Game.CurrentPlayer.getOwnedSpaces().Exists(x => x.XAMLID == ID.ToString()))
            {
                BtnAction_Click(sender, (RoutedEventArgs)e);
            }
        }
    }
}
