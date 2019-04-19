using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Monopoly_Game {
    /// <summary>
    /// R.C. 4/17/2019
    /// A type of space object
    /// The type property for this object refers to either the Loot Crate or the Opportunity
    /// </summary>
    public class Card:Space {
        private string cardType;
        
        public string CardType { get { return cardType; } set { cardType = value; } }

        public Card (string id, TextBlock name, Button btn, WrapPanel moveArea) : base(id, name, btn, moveArea) {
            // *** Consider a string parameter to set the type immediately ***
        }
    }
}
