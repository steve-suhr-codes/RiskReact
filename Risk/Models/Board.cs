using System.Collections.Generic;
using System.Linq;

namespace Risk.Models
{
    public class Board
    {
        public SortedList<int, Country> Countries { get; set; }
        public Dictionary<string, Country> CountriesByName { get; set; }
        public Dictionary<string, Continent> Continents { get; set; }

        public List<Country> GetUnclaimedCountries()
        {
            var unclaimedCountries = Countries
                .Where(x => x.Value.OccupyingPlayer == null)
                .Select(x => x.Value).ToList();

            return unclaimedCountries;
        }

        public List<Continent> GetContinentsOtherPlayersCanGet(string playerName)
        {
            return Continents
                .Where(x => x.Value.PlayersCountryCount.Count(pcc => pcc.Key != null) <= 1)
                .Select(x => x.Value).ToList();
        }

        public List<Continent> GetContinentsPlayerCanGet(string playerName)
        {
            var result = Continents
                .Where(x => x.Value.Countries.All(
                    c => c.OccupyingPlayer == null || c.OccupyingPlayer.Name == playerName))
                .Select(x => x.Value).ToList();

            return result;
        }
    }
}
