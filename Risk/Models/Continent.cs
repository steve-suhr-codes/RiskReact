using System.Collections.Generic;
using System.Linq;

namespace Risk.Models
{
    public class Continent
    {
        public string Name { get; set; }
        public int ArmyBonus { get; set; }
        public List<Country> Countries { get; set; }

        public Dictionary<string, int> PlayersCountryCount
        {
            get
            {
                var result = Countries
                    .GroupBy(c => c.OccupyingPlayer?.Name ?? string.Empty)
                    .ToDictionary(grp => grp.Key, grp => grp.Sum(x => 1));

                return result;
            }
        }

        public List<Country> CountriesLeftToClaim
        {
            get
            {
                var result = Countries
                    .Where(c => c.OccupyingPlayer == null)
                    .ToList();

                return result;
            }
        }
    }
}
