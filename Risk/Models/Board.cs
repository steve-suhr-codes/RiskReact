using System.Collections.Generic;

namespace Risk.Models
{
    public class Board
    {
        public SortedList<int, Country> Countries { get; set; }
        public Dictionary<string, Country> CountryDictionary { get; set; }
    }
}
