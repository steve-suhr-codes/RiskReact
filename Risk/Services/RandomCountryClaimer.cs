using System;
using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class RandomCountryClaimer : ICountryClaimer
    {
        private Random _random = new Random();
        public bool ClaimCountry(Player player, Board board)
        {
            var availableCountries = board.GetUnclaimedCountries();

            if (availableCountries.Count == 0)
                return false;

            var randomIndex = _random.Next(availableCountries.Count);
            var chosenCountry = availableCountries[randomIndex];

            player.ClaimCountry(chosenCountry);

            player.Ledger.Log($"Player {player.Name} is picking a random country, {chosenCountry.Name}.");
            return true;
        }
    }
}
