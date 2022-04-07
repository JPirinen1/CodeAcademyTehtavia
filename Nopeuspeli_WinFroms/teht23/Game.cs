using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace teht23
{
    public class Game
    {
        public int Drafted { get; set; }
        public int PreviousDraft { get; set; } = 0;
        public int Points { get; set; } = 0;
        public int Seconds { get; set; } = 0;
        public int Minutes { get; set; } = 0;


        public Game()
        {

        }


    }
}
