using System;
using System.Collections.Generic;
using System.Linq;
using Risk.Services.Interfaces;

namespace Risk.Models
{
    public class Player
    {
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public int ArmiesToDistribute { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<Country> Countries { get; set; } = new List<Country>();

        private ICountryClaimer _countryClaimer { get; set; }
        private ITroopReenforcer _troopReenforcer { get; set; }
        private IAttacker _attacker { get; set; }
        private Logger _logger { get; set; }

        public Player(ICountryClaimer countryClaimer, ITroopReenforcer troopReenforcer, IAttacker attacker, Logger logger)
        {
            _countryClaimer = countryClaimer;
            _troopReenforcer = troopReenforcer;
            _attacker = attacker;
            _logger = logger;
        }

        public void ClaimCountry(Country country)
        {
            if (country.OccupyingPlayer != null)
                throw new Exception($"Unable to claim {country.Name} for {Name} because it is already claimed by {country.OccupyingPlayer.Name}.");

            country.OccupyingPlayer = this;
            Countries.Add(country);
            DropArmies(country, 1);
        }

        public bool ClaimCountry(Board board)
        {
            return _countryClaimer.ClaimCountry(this, board);
        }

        public bool Reenforce(int armiesToDrop)
        {
            return _troopReenforcer.Reenforce(this, armiesToDrop);
        }

        public void Attack()
        {
            _attacker.Attack(this);
        }

        public void Fortify()
        {

        }

        public bool Reenforce()
        {
            return Reenforce(ArmiesToDistribute);
        }

        public void GainArmies(int newArmies)
        {
            _logger.LogLine($"* {Name} gets {newArmies} new armies!");
            ArmiesToDistribute += newArmies;
        }

        public void DropArmies(Country country, int armyCount)
        {
            if (country.OccupyingPlayer == null)
                throw new Exception($"Unable to place army for {Name} in {country.Name} because it is not owned by anybody.");

            if (country.OccupyingPlayer.Name != Name)
                throw new Exception($"Unable to place army for {Name} in {country.Name} because it is owned by {country.OccupyingPlayer.Name}.");

            if (Countries.All(c => c.Name != country.Name))
                throw new Exception($"Unable to place army for {Name} in {country.Name} because it is not in their country list.");

            if (armyCount > ArmiesToDistribute)
                throw new Exception($"Unable to drop {armyCount} armies for {Name} because only {ArmiesToDistribute} are available.");

            country.OccupyingArmyCount += armyCount;
            ArmiesToDistribute -= armyCount;

            _logger.LogLine($"* {Name} drops {armyCount} armies into {country.Name} for a total of {country.OccupyingArmyCount}.  {ArmiesToDistribute} armies left to drop.");
        }

        public void ConquerCountry(Country winner, Country loser, int invadingArmyCount)
        {
            if (loser.OccupyingPlayer == null)
                throw new Exception($"Unable to conquer country {loser.Name} for {Name} because it is not claimed by anybody.");

            if (loser.OccupyingPlayer.Name == Name)
                throw new Exception($"Unable to conquer country {loser.Name} for {Name} because it is already occupied by {Name}.");

            if (winner.OccupyingPlayer == null)
                throw new Exception($"Unable to conquer from the country {winner.Name} for {Name} because it is not claimed by anybody.");

            if (winner.OccupyingPlayer.Name != Name)
                throw new Exception($"Unable to conquer from the country {winner.Name} for {Name} because it is not occupied by {Name}.");

            if (loser.OccupyingArmyCount > 0)
                throw new Exception($"Unable to conquer country {loser.Name} for {Name} because there are still {loser.OccupyingArmyCount} armies defending.");

            if (invadingArmyCount > winner.OccupyingArmyCount - 1)
                throw new Exception($"Unable to invade with {invadingArmyCount} for {Name} from {winner.Name}.  Only {winner.OccupyingArmyCount} armies remain.");

            loser.OccupyingPlayer.Countries.Remove(loser);
            winner.OccupyingPlayer.Countries.Add(loser);
            loser.OccupyingPlayer = winner.OccupyingPlayer;

            winner.OccupyingArmyCount -= invadingArmyCount;
            loser.OccupyingArmyCount += invadingArmyCount;
        }
    }
}
