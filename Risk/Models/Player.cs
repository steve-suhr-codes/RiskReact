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
        private ITurnTaker _turnTaker { get; set; }

        public Player(ICountryClaimer countryClaimer, ITroopReenforcer troopReenforcer, ITurnTaker turnTaker)
        {
            _countryClaimer = countryClaimer;
            _troopReenforcer = troopReenforcer;
            _turnTaker = turnTaker;
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

        public void GainArmies()
        {

        }

        public void TakeTurn()
        {
            _turnTaker.TakeTurn(this);
        }
    }
}
