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
using System.Windows.Shapes;

namespace Monopoly_Game.Forms
{
    /// <summary>
    /// Interaction logic for PurchaseProperty.xaml
    /// </summary>
    public partial class PurchaseProperty : Window
    {
        private LandlordsBoard _LandlordsBoard = null;

        public PurchaseProperty(LandlordsBoard landlordsBoard)
        {
            InitializeComponent();
            this._LandlordsBoard = landlordsBoard;
            Property property = (Property) GameEngine.Game.CurrentPlayer.CurrentSpace;
            string propertyName = property.Name;
            int propertyCost = property.Value;
            tbPropertyCost.Text = propertyName + " costs " + propertyCost + " would you like to purchase it?";

            if(property.Value > GameEngine.Game.CurrentPlayer.CurrentFunds)
            {
                tbPropertyCost.Text += " If so you'll need to find some more cash!";
            }
        }

        private void BtnConfirmBuy_Click(object sender, RoutedEventArgs e)
        {
            Player player = GameEngine.Game.CurrentPlayer;
            Property property = (Property) GameEngine.Game.CurrentPlayer.CurrentSpace;

            player.purchaseProperty(ref property);
            _LandlordsBoard.DisplayPropertyOwnerships();
            _LandlordsBoard.DisplayPlayerMoney();
                
            this.Close();
        }

        private void BtnDenyBuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
