using System.Collections.Generic;

namespace Risk.Models
{
    public class Continent
    {
        public string Name { get; set; }
        public int ArmyBonus { get; set; }
        public List<Country> Countries { get; set; }
    }
}
