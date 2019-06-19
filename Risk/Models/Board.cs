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
    }
}
