using NumericTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTicTacToe
{
    internal class Board
    {
        private int[,] cells = new int[3, 3];

        public bool ValidateMove(int row, int col, int value)
        {
            return cells[row, col] == 0;
        }

        public void ApplyMove(Move move)
        {
            cells[move.Position.X, move.Position.Y] = move.Value;
            DisplayBoard(); // Display board after every move
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (cells[i, 0] + cells[i, 1] + cells[i, 2] == 15 || cells[0, i] + cells[1, i] + cells[2, i] == 15)
                    return true;
            }
            if (cells[0, 0] + cells[1, 1] + cells[2, 2] == 15 || cells[0, 2] + cells[1, 1] + cells[2, 0] == 15)
                return true;
            return false;
        }
        public void DisplayBoard()
        {
            Console.WriteLine("Current Game Board:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(cells[i, j] == 0 ? "-\t" : cells[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
