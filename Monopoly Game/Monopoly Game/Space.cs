using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Monopoly_Game
{
    /// <summary>
    /// Created by ????/Team
    /// Changes:
    ///     1. Refined for Monopoly (instead of TicTacToe) by including addtional properties of a Space on 03/29/2018 by Fernando Munoz
    /// </summary>
    public class Space
    {
        private string _XAMLID;
        private TextBlock _TBName;
        private string _Description;
        private Button _Button;
        private WrapPanel _PlayerAreaStackPanel;
        private Image _Image;
        private bool _Playable = true;

        public Space(string id, TextBlock tbName, Button btn, WrapPanel moveArea)
        {
            _XAMLID = id;
            _TBName = tbName;
            _Button = btn;
            _PlayerAreaStackPanel = moveArea;
        }


        public string XAMLID { get { return _XAMLID; } }
        public TextBlock NameTB { get { return _TBName; } }
        public string Description { get { return _Description; } set { _Description = value; } }
        public Button Button { get { return _Button; } }
        public WrapPanel PlayerAreaStackPanel { get { return _PlayerAreaStackPanel; } }
        public Image Image { get { return _Image; } set { _Image = value; } }
        public bool Playable { get { return _Playable; } set { _Playable = value; } }

        public string Name
        {
            get
            {
                if (_TBName != null)
                {
                    return _TBName.Text;
                }
                return "N/A";
            }
        }


    }
}