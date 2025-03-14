using NumericTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NumericTicTacToe
{
    internal class ComputerPlayer: Player
    {
        private Random rand = new Random();
        public override Move MakeMove(Board board)
        {
            int row, col, value;
            do
            {
                row = rand.Next(0, 3);
                col = rand.Next(0, 3);
                value = (PlayerType == 'O') ? rand.Next(1, 10) | 1 : rand.Next(1, 10) & ~1;
            } while (!board.ValidateMove(row, col, value));

            Console.WriteLine($"Computer ({Name}) plays: {row} {col} {value}");
            return new Move { Position = (row, col), Value = value, Player = this, Timestamp = DateTime.Now.ToString(), IsValid = true };
        }
    }
}
