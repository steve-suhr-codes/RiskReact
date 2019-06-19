using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Risk
{
    public class Logger
    {
        private Game _game { get; set; }

        public Logger(Game game)
        {
            _game = game;
        }

        public void LogGame()
        {
            Console.WriteLine("::: GAME :::");
            Console.WriteLine($"::: Game Phase {_game.GamePhase} :::");
            LogBoard();
        }

        public void LogBoard()
        {
            Console.WriteLine("::: The Board :::");
            foreach (var countryKeyValue in _game.Table.Board.Countries)
            {
                Console.WriteLine($"{countryKeyValue.Key}\t- {countryKeyValue.Value.Name} [ Player = {countryKeyValue.Value.OccupyingPlayer?.Name}, Armies = {countryKeyValue.Value.OccupyingArmyCount} ]");
            }
            Console.WriteLine();


        }


    }
}
