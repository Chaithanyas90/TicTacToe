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
            string folderPath = Console.ReadLine();

            if (!IsValidFilePath(folderPath))//C:\Users\A0821423\Downloads\Keerthan\File.txt
            {
                Console.WriteLine("Invalid file path. Please enter a valid path.");
                return;
            }

            string fileName = "Numeric_Tic_Tac_Toe_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            string filePath = Path.Combine(folderPath, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                var player = string.Empty;
                foreach (var move in moves)
                {
                    player = move.Player.Name;
                    writer.WriteLine($"{move.Player.Name},{move.Position.X},{move.Position.Y},{move.Value},{move.Timestamp}");
                }
                writer.WriteLine($"{player} has won!");
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
