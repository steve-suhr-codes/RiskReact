using Risk.Models;
using Risk.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Risk.Services;

namespace Risk
{
    public enum GamePhase
    {
        Pending,
        Claim,
        Place,
        Play,
        Finished
    }

    public class Game
    {
        public Table Table { get; set; }
        public GamePhase GamePhase { get; set; } = GamePhase.Pending;

        private IBoardCreator _boardCreator { get; set; }
        private Logger _logger { get; set; }

        public Game(IBoardCreator boardCreator)
        {
            _boardCreator = boardCreator;
            _logger = new Logger(this);
        }

        public void StartGame()
        {
            var armiesPerPlayer = 108 / 4;
            var countryClaimer = new RandomCountryClaimer();
            var troopReenforcer = new RandomTroopReenforcer();
            Table = new Table
            {
                Board = _boardCreator.CreateBoard(),
                Players = new List<Player>
                {
                    new Player(countryClaimer, troopReenforcer)
                    {
                        Name = "Player 1",
                        Color = PlayerColor.Red,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer, troopReenforcer)
                    {
                        Name = "Player 2",
                        Color = PlayerColor.Blue,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer, troopReenforcer)
                    {
                        Name = "Player 3",
                        Color = PlayerColor.Purple,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer, troopReenforcer)
                    {
                        Name = "Player 4",
                        Color = PlayerColor.Yellow,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                }
            };

            GamePhase = GamePhase.Claim;
            _logger.LogGame();
        }

        public bool PlayTurn()
        {
            var moreCountriesToClaim = true;
            while (moreCountriesToClaim)
            {
                moreCountriesToClaim = Table.CurrentPlayer.ClaimCountry(Table.Board);
                Table.NextTurn();
            }

            while (Table.Players.Any(p => p.ArmiesToDistribute > 0))
            {
                Table.CurrentPlayer.Reenforce(1);
                Table.NextTurn();
            }

            return true;
        }

        private void Setup()
        {
        }
    }
}
