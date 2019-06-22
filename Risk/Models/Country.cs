using System.Collections.Generic;

namespace Risk.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Continent { get; set; }
        public List<Country> AdjacentCountries { get; set; }
        public Player OccupyingPlayer { get; set; }
        public int OccupyingArmyCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
