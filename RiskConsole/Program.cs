using System;
using System.ComponentModel.Design;
using Risk;
using Risk.Services;

namespace RiskConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new RiskBoardCreator(), new RiskArmyDelegator());
            game.StartGame();

            //Claim
            game.FastForwardCurrentPhase();

            //Place
            game.FastForwardCurrentPhase();

            var stillPlaying = true;
            while (stillPlaying)
            {
                Console.WriteLine("Enter to advance turn");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    game.PlayTurn();
                else if (input == "b")
                    game.LogGame();
                else 
                    Console.WriteLine($"Unknown command {input}");
            }

            Console.WriteLine("Finished.  Enter to exit.");
            Console.ReadLine();
        }
    }
}
