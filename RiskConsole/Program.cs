using System;
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
                game.LogGame();
                Console.WriteLine("Enter to advance turn");
                Console.ReadLine();
                game.PlayTurn();
            }

            Console.WriteLine("Finished.  Enter to exit.");
            Console.ReadLine();
        }
    }
}
