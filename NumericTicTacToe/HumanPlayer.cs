using NumericTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NumericTicTacToe
{
    internal class HumanPlayer : Player
    {
        public override Move MakeMove(Board board)
        {
            int row, col, value;
            while (true)
            {
                try
                {
                    Console.WriteLine($"{Name}, it's your turn.");
                    Console.Write("Enter Row (0-2): ");
                    while (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row > 2)
                        Console.Write("Invalid row. Enter again (0-2): ");

                    Console.Write("Enter Column (0-2): ");
                    while (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col > 2)
                        Console.Write("Invalid column. Enter again (0-2): ");

                    Console.Write("Enter Value (1-9): ");
                    while (!int.TryParse(Console.ReadLine(), out value) || value < 1 || value > 9)
                        Console.Write("Invalid value. Enter again (1-9): ");

                    if (!board.ValidateMove(row, col, value))
                    {
                        Console.WriteLine("Invalid move. The cell is already occupied. Try again.");
                        continue;
                    }

                    return new Move { Position = (row, col), Value = value, Player = this, Timestamp = DateTime.Now.ToString(), IsValid = true };
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                }
            }
        }
    }
}
