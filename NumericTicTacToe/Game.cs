using NumericTicTacToe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTicTacToe
{
    public class Game
    {
        private Board board = new Board();
        private UndoRedoManager undoRedoManager = new UndoRedoManager();
        private SaveManager saveManager = new SaveManager();
        private List<Player> players;
        private int currentPlayerIndex = 0;
        private List<Move> moveHistory = new List<Move>();
        private HashSet<int> usedNumbers = new HashSet<int>();

        public Game(bool humanVsHuman)
        {
            players = new List<Player>
        {
            new HumanPlayer { Name = "Player 1", PlayerType = 'O' },
            humanVsHuman ? new HumanPlayer { Name = "Player 2", PlayerType = 'E' } : new ComputerPlayer { Name = "Computer", PlayerType = 'E' }
        };
        }

        public void StartGame()
        {
            board.DisplayBoard();
            while (true)
            {
                Player currentPlayer = players[currentPlayerIndex];
                int value;
                do
                {
                    Move move = currentPlayer.MakeMove(board);
                    value = move.Value;

                    if (usedNumbers.Contains(value))
                    {
                        Console.WriteLine($"Value {value} has already been used. Choose a different number.");
                    }
                    else if (move.IsValid)
                    {
                        board.ApplyMove(move);
                        undoRedoManager.RecordMove(move);
                        moveHistory.Add(move);
                        usedNumbers.Add(value);

                        if (board.CheckWin())
                        {
                            Console.WriteLine($"{currentPlayer.Name} won!");
                            AskToSaveGame();
                            AskForReplay();
                            return;
                        }
                        currentPlayerIndex = 1 - currentPlayerIndex;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move! try again.");
                    }
                }while (true);
            }
        }

        private void AskToSaveGame()
        {
            Console.Write("Do you want to save the game? (yes/no): ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                saveManager.SaveGame(moveHistory);
            }
        }

        private void AskForReplay()
        {
            Console.Write("Do you want to play again? (1: Human vs Human, 2: Human vs Computer, 0 or * to exit): ");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "2")
            {
                Game game = new Game(choice == "1");
                game.StartGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}
