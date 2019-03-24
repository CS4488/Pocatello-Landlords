using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LandlordsBoard.xaml
    /// </summary>
    public partial class LandlordsBoard : Page
    {
        public LandlordsBoard()
        {
            InitializeComponent();


            int iteration = 0;
            foreach (UIElement ui in LogicalTreeHelper.GetChildren(BoardWrapper))
            {
                foreach (UIElement inner in LogicalTreeHelper.GetChildren(ui))
                {
                    if (inner is TextBlock)
                    {
                        TextBlock tb = (TextBlock)inner;
                        setTitle(tb, iteration);
                    }
                }
                iteration++;
            }
        }

        private void setTitle(TextBlock tb, int iteration)
        {
            String path = "../../Database/properties.csv";
            string[] lines = File.ReadAllLines(path);
            for(int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("\"", "");
            }

            if (iteration == 1)
            {
                string[] values = lines[22].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 3)
            {
                string[] values = lines[21].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 6)
            {
                string[] values = lines[20].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 8)
            {
                string[] values = lines[19].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 9)
            {
                string[] values = lines[18].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 11)
            {
                string[] values = lines[17].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 13)
            {
                string[] values = lines[16].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 14)
            {
                string[] values = lines[15].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 16)
            {
                string[] values = lines[14].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 18) {
                string[] values = lines[13].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 19) {
                string[] values = lines[12].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 21) {
                string[] values = lines[11].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 23) {
                string[] values = lines[10].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 24) {
                string[] values = lines[9].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 26) {
                string[] values = lines[8].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 27) {
                string[] values = lines[7].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 29) {
                string[] values = lines[6].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 31) {
                string[] values = lines[5].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 32) {
                string[] values = lines[4].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 34) {
                string[] values = lines[3].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 37) {
                string[] values = lines[2].Split(',');
                tb.Text = values[1];
            }
            else if (iteration == 39) {
                Console.WriteLine("Found boardwalk");
                string[] values = lines[1].Split(',');
                Console.WriteLine(values[1]);
                tb.Text = values[1];
            }

        }

    }
}
