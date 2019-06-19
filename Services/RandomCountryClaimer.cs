using System;
using System.Linq;
using RiskReact.Models.Entities;
using RiskReact.Services.Interfaces;

namespace RiskReact.Services
{
    public class RandomCountryClaimer : ICountryClaimer
    {
        public bool ClaimCountry(Player player, Board board)
        {
            var availableCountries = board.Countries.Where(c => c.OccupyingPlayer == null).ToList();

            if (availableCountries.Count == 0)
                return false;

            var chosenCountry = availableCountries[0];

            chosenCountry.OccupyingPlayer = player;
            player.DropArmies(chosenCountry, 1);

            return true;
        }
    }
}
