using Risk.Models;
using System.Collections.Generic;

namespace Risk.Services.Interfaces
{
    public interface IArmyDelegator
    {
        int GetStartingArmyCount(int playerCount);
        int CalculateArmiesGained(List<Country> countriesOwned, Dictionary<string, Continent> continents);
    }
}
