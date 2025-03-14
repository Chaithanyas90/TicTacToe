using NumericTicTacToe;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose Game Mode:");
        Console.WriteLine("1. Human vs Human");
        Console.WriteLine("2. Human vs Computer");
        string choice = Console.ReadLine();
        Game game = new Game(choice == "1");
        game.StartGame();
    }
}
