/*
 * Eventualy we will want to give this an instatnce of game 
 * and handle the graphics here, for now that is done in
 * mainwindow.xaml.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Game
{
    class DisplayManager
    {
        Game game;
        public DisplayManager(Game game)
        {
            this.game = game;
        }
    }
}
