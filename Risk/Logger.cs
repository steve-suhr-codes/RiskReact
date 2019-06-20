using System;

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
            LogCurrentPlayer();
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
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

        public void LogCurrentPlayer()
        {
            Console.WriteLine($"::: Current Player : {_game.Table.CurrentPlayer.Name} :::");
            Console.WriteLine($"Countries : {_game.Table.CurrentPlayer.Countries.Count} :::");
            Console.WriteLine($"Armies to distribute : {_game.Table.CurrentPlayer.ArmiesToDistribute} :::");
        }

        public void LogLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
