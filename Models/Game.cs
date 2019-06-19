using RiskReact.Models.Entities;
using RiskReact.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using RiskReact.Services;

namespace RiskReact.Models
{
    public class Game
    {
        public Table Table { get; set; }

        private IBoardCreator _boardCreator { get; set; }

        public Game(IBoardCreator boardCreator)
        {
            _boardCreator = boardCreator;
        }

        public void StartGame()
        {
            Setup();

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


        }

        private void Setup()
        {
            var armiesPerPlayer = 108 / 4;
            var countryClaimer = new RandomCountryClaimer();
            Table = new Table
            {
                Board = _boardCreator.CreateBoard(),
                Players = new List<Player>
                {
                    new Player(countryClaimer)
                    {
                        Name = "Player 1",
                        Color = PlayerColor.Red,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer)
                    {
                        Name = "Player 2",
                        Color = PlayerColor.Blue,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer)
                    {
                        Name = "Player 3",
                        Color = PlayerColor.Purple,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer)
                    {
                        Name = "Player 4",
                        Color = PlayerColor.Yellow,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                }
            };
        }
    }
}
