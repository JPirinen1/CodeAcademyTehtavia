using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace teht23
{
    public class Player
    {
        //tätä luokkaa käytetään pelaajien lisäämiseen listaan
        public string Name { get; private set; }
        public int Points { get; private set; }

        public Player()
        {

        }

        public Player(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}
