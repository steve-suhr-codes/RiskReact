using System.Collections.Generic;

namespace RiskReact.Models.Entities
{
    public class Board
    {
        public List<Country> Countries { get; set; }
        public Dictionary<string, Country> CountryDictionary { get; set; }
    }
}
