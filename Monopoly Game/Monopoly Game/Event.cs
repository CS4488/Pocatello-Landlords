﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Monopoly_Game
{
    /// <summary>
    /// A type of space object
    /// The type property for this object refers to either the Loot Crate or the Opportunity
    /// R.C. Type changed to be the Go to Jail or Pass Go spaces - 4/17/2019
    /// </summary>
    class Event : Space
    {
        private string _Type;

        public string Type { get { return _Type; } set { _Type = value; } }

        public Event(string id, TextBlock name, Button btn, WrapPanel moveArea) : base(id, name, btn, moveArea)
        {

        }
    }
}