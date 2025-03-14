using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTicTacToe.Models
{
    internal abstract class Player
    {
        public string Name { get; set; }
        public char PlayerType { get; set; }
        public abstract Move MakeMove(Board board);
    }
}
