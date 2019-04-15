using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Monopoly_Game
{
    /// <summary>
    /// Created by Fernando Munoz
    /// April 14th, 2019
    /// 
    /// This class contains all the information of a token, an object that represents the player on the game board
    /// </summary>
    class Token
    {
        private Color _Color;
        private int _Height;
        private int _Width;
        private Image _Image;

        public Token(Image img, Color clr, int height, int width)
        {
            _Image = img;
            _Color = clr;
            _Height = height;
            _Width = width;
        }

        private Color Color
        {
            get => _Color;
            set => _Color = value;
        }

        private int Height
        {
            get => _Height;
            set => _Height = value;
        }

        private int Width
        {
            get => _Width;
            set => _Width = value;
        }

        private Image Image
        {
            get => _Image;
            set => _Image = value;
        }
    }
}
