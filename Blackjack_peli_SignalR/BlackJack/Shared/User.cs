using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Shared
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime ts { get; set; }
        public string State { get; set; }
        public int WinCount { get; set; }
        public int Score { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
        public List<Card> Aces { get; set; } = new List<Card>();
    }
}
