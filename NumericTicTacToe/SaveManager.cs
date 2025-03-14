using NumericTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTicTacToe
{
    internal class SaveManager
    {
        public void SaveGame(List<Move> moves)
        {
            Console.Write("Enter the file path to save the game: ");
            string filePath = Console.ReadLine();

            if (!IsValidFilePath(filePath))
            {
                Console.WriteLine("Invalid file path. Please enter a valid path.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var move in moves)
                {
                    writer.WriteLine($"{move.Player.Name},{move.Position.X},{move.Position.Y},{move.Value},{move.Timestamp}");
                }
            }
            Console.WriteLine("Game successfully saved.");
        }

        private bool IsValidFilePath(string filePath)
        {
            try
            {
                Path.GetFullPath(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
