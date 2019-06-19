using Risk.Models;
using Risk.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Risk.Services
{
    public class RiskArmyDelegator : IArmyDelegator
    {
        public int GetStartingArmyCount(int playerCount)
        {
            switch (playerCount)
            {
                case 3:
                    return 35;
                case 4:
                    return 30;
                case 5:
                    return 25;
                case 6:
                    return 20;
                default:
                    throw new Exception($"Don't know how many armies to start with when playing with {playerCount} players.");
            }
        }

        public int CalculateArmiesGained(List<Country> countriesOwned, Dictionary<string, Continent> continents)
        {
            if (countriesOwned.Count == 0) return 0;

            var armiesGained = countriesOwned.Count / 3;

            var playerName = countriesOwned[0].OccupyingPlayer.Name;

            var continentsAtLeastPartiallyOwned = countriesOwned.Select(c => c.Continent).Distinct().ToList();
            foreach (var continentName in continentsAtLeastPartiallyOwned)
            {
                var continentOwned = continents[continentName].Countries.All(x => x.OccupyingPlayer.Name == playerName);
                if (continentOwned)
                {
                    armiesGained += continents[continentName].ArmyBonus;
                }
            }

            return armiesGained;
        }
    }
}
