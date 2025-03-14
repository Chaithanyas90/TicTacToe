using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTicTacToe.Models
{
    internal class Move
    {
        public int Value { get; set; }
        public (int X, int Y) Position { get; set; }
        public Player Player { get; set; }
        public string Timestamp { get; set; }
        public bool IsValid { get; set; }
    }
}
