using System;
using System.Collections.Generic;
using Risk.Services.Interfaces;

namespace Risk.Models
{
    public enum PlayerColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }

    public class Player
    {
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public int ArmiesToDistribute { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<Country> Countries { get; set; } = new List<Country>();

        private ICountryClaimer _countryClaimer { get; set; }
        private ITroopReenforcer _troopReenforcer { get; set; }

        public Player(ICountryClaimer countryClaimer, ITroopReenforcer troopReenforcer)
        {
            _countryClaimer = countryClaimer;
            _troopReenforcer = troopReenforcer;
        }

        public void DropArmies(Country country, int armyCount)
        {
            if (country.OccupyingPlayer == null)
                throw new Exception($"Unable to place army for {Name} in {country.Name} because it is not owned by anybody");

            if (country.OccupyingPlayer.Name != Name)
                throw new Exception($"Unable to place army for {Name} in {country.Name} because it is owned by {country.OccupyingPlayer.Name}");

            if (armyCount > ArmiesToDistribute)
                throw new Exception($"Unable to drop {armyCount} armies for {Name} because only {ArmiesToDistribute} are available.");

            country.OccupyingArmyCount += armyCount;
            ArmiesToDistribute -= armyCount;
        }

        public bool ClaimCountry(Board board)
        {
            return _countryClaimer.ClaimCountry(this, board);
        }

        public bool Reenforce(int armiesToDrop)
        {
            return _troopReenforcer.Reenforce(this, armiesToDrop);
        }
    }
}
