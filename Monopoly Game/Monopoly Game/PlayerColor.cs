using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;

namespace Monopoly_Game
{
    /* M.S. PlayerColors Class and enum 4/16/19
     * Methods for Color Handling should be stored here
     * 
     * M.S. I am unfamiliar with a method for changing the color of a png... It should be set up to work, if someone knows better.
     * 
    */ 
    public enum PlayerColors { Red, Blue, Black, Green, Yellow, Purple, Orange, Gray };

    public static class PlayerColor
    {
        public static Color AssignColor(int input)
        {
            switch ((PlayerColors)input)
            {
                case PlayerColors.Red:      return Color.FromRgb(255, 0, 0);
                case PlayerColors.Blue:     return Color.FromRgb(0, 0, 225);
                case PlayerColors.Black:    return Color.FromRgb(0, 0, 0);
                case PlayerColors.Green:    return Color.FromRgb(0, 128, 0);
                case PlayerColors.Yellow:   return Color.FromRgb(255, 255, 0);
                case PlayerColors.Purple:   return Color.FromRgb(128, 0, 128);
                case PlayerColors.Orange:   return Color.FromRgb(255, 165, 0);
                default:                    return Color.FromRgb(128, 128, 128); //gray
            }
        }
        public static Image ChangeColor(Image inputImage, Color inputColor)
        {
            // M.S. Here is where I need help :)
            return inputImage; // currently does nothing to the image.
        }
    }
}
