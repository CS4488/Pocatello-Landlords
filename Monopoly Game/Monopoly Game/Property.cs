using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Monopoly_Game
{
    /*
         * Rex Christesnsen: Property class 1.0
         * 
         * Please describe changes made here; along with your name, date, and version:
         * Adds public Constructor for use with Tic Tac Toe test harness - Rex Christensen - 27JAN1019 - v1
         * 
         */

    public class Property : Space
    {
        private int _Value;
        private TextBlock _ValueTB;
        private int _OwnerPlayerID;
        private StackPanel _BuildingArea;

        public int OwnerPlayerID { get { return _OwnerPlayerID; } set { _OwnerPlayerID = value; } }
        public TextBlock ValueTB { get { return _ValueTB; } }
        public StackPanel BuildingArea { get { return _BuildingArea; } }

        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value.ToString() != _ValueTB.Text)
                {
                    _ValueTB.Text = value.ToString();
                }
                _Value = value;

            }
        }


        public Property(string id, TextBlock name, Button btn, WrapPanel moveArea, StackPanel bldgArea, TextBlock valueTB) : base(id, name, btn, moveArea)
        {
            _OwnerPlayerID = -1;
            _Value = 0;
            _BuildingArea = bldgArea;
            _ValueTB = valueTB;
        }

        ///// <summary>
        ///// This constructor for use with the Tic Tac Toe test harness
        ///// Rex Christensen - 27JAN2019 - v1
        ///// </summary>
        ///// <param name="inputValue"></param>
        public Property(string id, TextBlock name, Button btn, WrapPanel moveArea, int inputValue) : base(id, name, btn, moveArea)
        {
            _OwnerPlayerID = -1;
            _Value = inputValue;
        }

        public Property(string id, TextBlock name, Button btn, WrapPanel moveArea, int inputOwner, int inputValue) : base(id, name, btn, moveArea)
        {
            _OwnerPlayerID = inputOwner;
            _Value = inputValue;
        }
    }
}
