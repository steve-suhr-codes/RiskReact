using System;
using Risk.Models;
using Risk.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Risk.Services;

namespace Risk
{
    public class Game
    {
        public Table Table { get; set; }
        public GamePhase GamePhase { get; set; } = GamePhase.Pending;
        public TurnPhase TurnPhase { get; set; } = TurnPhase.None;

        private IBoardCreator _boardCreator { get; set; }
        private IArmyDelegator _armyDelegator { get; set; }
        private Logger _logger { get; set; }

        public Game(IBoardCreator boardCreator, IArmyDelegator armyDelegator)
        {
            _boardCreator = boardCreator;
            _armyDelegator = armyDelegator;
            _logger = new Logger(this);
        }

        public void StartGame()
        {
            var armiesPerPlayer = _armyDelegator.GetStartingArmyCount(4);

            var countryClaimer = new RandomCountryClaimer();
            var troopReenforcer = new RandomTroopReenforcer();
            var attacker = new RandomAttacker(new EvenDice(_logger));

            Table = new Table
            {
                Board = _boardCreator.CreateBoard(),
                Players = new List<Player>
                {
                    new Player(countryClaimer, troopReenforcer, attacker, _logger)
                    {
                        Name = "Player 1",
                        Color = PlayerColor.Red,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer, troopReenforcer, attacker, _logger)
                    {
                        Name = "Player 2",
                        Color = PlayerColor.Blue,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer, troopReenforcer, attacker, _logger)
                    {
                        Name = "Player 3",
                        Color = PlayerColor.Purple,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                    new Player(countryClaimer, troopReenforcer, attacker, _logger)
                    {
                        Name = "Player 4",
                        Color = PlayerColor.Yellow,
                        ArmiesToDistribute = armiesPerPlayer
                    },
                }
            };

            GamePhase = GamePhase.Claim;
        }

        public void PlayTurn()
        {
            switch (GamePhase)
            {
                case GamePhase.Claim:
                    ClaimCountry();
                    if (Table.Board.GetUnclaimedCountries().Count == 0)
                        GamePhase = GamePhase.Place;
                    Table.NextTurn();
                    break;

                case GamePhase.Place:
                    Reenforce(1);
                    if (Table.Players.All(p => p.ArmiesToDistribute == 0))
                    {
                        GamePhase = GamePhase.Play;
                        TurnPhase = TurnPhase.GainArmies;
                    }
                    Table.NextTurn();
                    break;

                case GamePhase.Play:
                    TakeTurn();
                    if (TurnPhase == TurnPhase.None)
                    {
                        //turn over
                        TurnPhase = TurnPhase.GainArmies;
                        Table.NextTurn();
                    }
                    if (Table.Players.Any(p => p.Countries.Count == Table.Board.Countries.Count))
                    {
                        //game over
                        GamePhase = GamePhase.Finished;
                    }
                    break;

                default:
                    _logger.LogLine($"Unhandled game phase {GamePhase}");
                    return;
            }

        }

        public void LogGame()
        {
            _logger.LogGame();
        }

        public void FastForwardCurrentPhase()
        {
            var startingPhase = GamePhase;
            _logger.LogLine($"Fast forwarding past {startingPhase} phase ...");
            while (GamePhase == startingPhase)
            {
                PlayTurn();
            }
            _logger.LogLine($"Fast forwarding done.  Moved from {startingPhase} phase to {GamePhase}.");
        }

        private void ClaimCountry()
        {
            Table.CurrentPlayer.ClaimCountry(Table.Board);
        }

        private void Reenforce(int armies)
        {
            Table.CurrentPlayer.Reenforce(armies);
        }

        private void TakeTurn()
        {
            switch (TurnPhase)
            {
                case TurnPhase.GainArmies:
                    if (Table.CurrentPlayer.ArmiesToDistribute == 0)
                    {
                        var newArmies = _armyDelegator.CalculateArmiesGained(Table.CurrentPlayer.Countries, Table.Board.Continents);
                        Table.CurrentPlayer.GainArmies(newArmies);
                        Table.CurrentPlayer.Reenforce();
                        TurnPhase = TurnPhase.Attack;
                    }
                    break;
                case TurnPhase.Attack:
                    Table.CurrentPlayer.Attack();
                    TurnPhase = TurnPhase.Fortify;
                    break;
                case TurnPhase.Fortify:
                    Table.CurrentPlayer.Fortify();
                    TurnPhase = TurnPhase.None;
                    break;
                case TurnPhase.None:
                default:
                    _logger.LogLine($"Unhandled turn phase {TurnPhase}.");
                    break;
        }
        }
    }
}
