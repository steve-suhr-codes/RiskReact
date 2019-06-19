using System;
using Risk;
using Risk.Services;

namespace RiskConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new RiskBoardCreator());
            game.StartGame();

            Console.WriteLine("Finished.  Enter to exit.");
            Console.ReadLine();
        }
    }
}
