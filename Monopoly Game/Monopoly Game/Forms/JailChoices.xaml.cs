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
    /// Interaction logic for JailChoices.xaml
    /// </summary>
    public partial class JailChoices : Window
    {
        public JailChoices()
        {
            InitializeComponent();
        }

        private void BtnPay50_Click(object sender, RoutedEventArgs e)
        {
            if (GameEngine.Game.CurrentPlayer.CurrentFunds >= 50)
            {
                GameEngine.Game.CurrentPlayer.CurrentFunds -= 50;
                GameEngine.Game.MovePlayerToSpace(GameEngine.Game.CurrentPlayer, GameEngine.Game.GameBoard.Spaces[10]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Insufficient funds, better try your luck with the dice or sell some properties!");
            }
        }

        private void BtnRollDice_Click(object sender, RoutedEventArgs e)
        {
            GameEngine.Game.CurrentPlayer.consecutiveJailTurns++;
            this.Close();
        }
    }
}
