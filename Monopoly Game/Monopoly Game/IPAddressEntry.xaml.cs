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

namespace Monopoly_Game {
    /// <summary>
    /// Interaction logic for IPAddressEntry.xaml
    /// </summary>

    /*
    * Rex Christesnsen: IPAddressEntry.xaml.cs class 1.0
    * 
    * Please describe changes made here; along with your name, date, and version:
    * Small window to allow user to enter IP address of game host - R.C. - 5APR19

    */

    public partial class IPAddressEntry : Window {
        public IPAddressEntry() {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e) {
            if (txtIPAddressEntry.Text != "") {
                GameEngine.IpAddress = txtIPAddressEntry.Text;
                this.Close();
            } else {
                MessageBox.Show("Please enter an IP Address to connect to.");
            }
        }
    }
}
