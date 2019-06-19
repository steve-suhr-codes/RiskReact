using Risk.Models;
using Risk.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Risk.Services
{
    public static class RiskConstants
    {
        public static class Continents
        {
            public const string NorthAmerica = "North America";
            public const string SouthAmerica = "South America";
            public const string Europe = "Europe";
            public const string Africa = "Africa";
            public const string Asia = "Asia";
            public const string Australia = "Australia";
        }

        public static class Countries
        {
            public const string Alaska = "Alaska";
            public const string NorthwestTerritory = "Northwest Territory";
            public const string Greenland = "Greenland";
            public const string Alberta = "Alberta";
            public const string Ontario = "Ontario";
            public const string Quebec = "Quebec";
            public const string WesternUnitedStates = "Western United States";
            public const string EasternUnitedStates = "Eastern United States ";
            public const string CentralAmerica = "Central America";

            public const string Venezuela = "Venezuela";
            public const string Peru = "Peru";
            public const string Brazil = "Brazil";
            public const string Argentina = "Argentina";

            public const string Iceland = "Iceland";
            public const string Scandinavia = "Scandinavia";
            public const string GreatBritain = "Great Britain";
            public const string NorthernEurope = "Northern Europe";
            public const string Ukraine = "Ukraine";
            public const string WesternEurope = "Western Europe";
            public const string SouthernEurope = "Southern Europe";

            public const string Egypt = "Egypt";
            public const string NorthAfrica = "North Africa";
            public const string EastAfrica = "East Africa";
            public const string Congo = "Congo";
            public const string SouthAfrica = "South Africa";
            public const string Madagascar = "Madagascar";

            public const string MiddleEast = "Middle East";
            public const string Afghanistan = "Afghanistan";
            public const string Ural = "Ural";
            public const string Siberia = "Siberia";
            public const string Yakutsk = "Yakutsk";
            public const string Kamchatka = "Kamchatka";
            public const string Irkutsk = "Irkutsk";
            public const string Mongolia = "Mongolia";
            public const string Japan = "Japan";
            public const string China = "China";
            public const string India = "India";
            public const string Siam = "Siam";

            public const string Indonesia = "Indonesia";
            public const string NewGuinea = "New Guinea";
            public const string WesternAustralia = "Western Australia";
            public const string EasternAustralia = "EasternAustralia";
        }
    }

    public class RiskBoardCreator : IBoardCreator
    {
        public Board CreateBoard()
        {
            var board = new Board
            {
                Countries = new SortedList<int, Country>
                {
                    {1, new Country { Name = RiskConstants.Countries.Alaska, Continent = RiskConstants.Continents.NorthAmerica }},
                    {2, new Country { Name = RiskConstants.Countries.NorthwestTerritory, Continent = RiskConstants.Continents.NorthAmerica }},
                    {3, new Country { Name = RiskConstants.Countries.Greenland, Continent = RiskConstants.Continents.NorthAmerica }},
                    {4, new Country { Name = RiskConstants.Countries.Alberta, Continent = RiskConstants.Continents.NorthAmerica }},
                    {5, new Country { Name = RiskConstants.Countries.Ontario, Continent = RiskConstants.Continents.NorthAmerica }},
                    {6, new Country { Name = RiskConstants.Countries.Quebec, Continent = RiskConstants.Continents.NorthAmerica }},
                    {7, new Country { Name = RiskConstants.Countries.WesternUnitedStates, Continent = RiskConstants.Continents.NorthAmerica }},
                    {8, new Country { Name = RiskConstants.Countries.EasternUnitedStates, Continent = RiskConstants.Continents.NorthAmerica }},
                    {9, new Country { Name = RiskConstants.Countries.CentralAmerica, Continent = RiskConstants.Continents.NorthAmerica }},

                    {10, new Country { Name = RiskConstants.Countries.Venezuela, Continent = RiskConstants.Continents.SouthAmerica }},
                    {11, new Country { Name = RiskConstants.Countries.Peru, Continent = RiskConstants.Continents.SouthAmerica }},
                    {12, new Country { Name = RiskConstants.Countries.Brazil, Continent = RiskConstants.Continents.SouthAmerica }},
                    {13, new Country { Name = RiskConstants.Countries.Argentina, Continent = RiskConstants.Continents.SouthAmerica }},

                    {14, new Country { Name = RiskConstants.Countries.Iceland, Continent = RiskConstants.Continents.Europe }},
                    {15, new Country { Name = RiskConstants.Countries.Scandinavia, Continent = RiskConstants.Continents.Europe }},
                    {16, new Country { Name = RiskConstants.Countries.GreatBritain, Continent = RiskConstants.Continents.Europe }},
                    {17, new Country { Name = RiskConstants.Countries.NorthernEurope, Continent = RiskConstants.Continents.Europe }},
                    {18, new Country { Name = RiskConstants.Countries.Ukraine, Continent = RiskConstants.Continents.Europe }},
                    {19, new Country { Name = RiskConstants.Countries.WesternEurope, Continent = RiskConstants.Continents.Europe }},
                    {20, new Country { Name = RiskConstants.Countries.SouthernEurope, Continent = RiskConstants.Continents.Europe }},

                    {21, new Country { Name = RiskConstants.Countries.Egypt, Continent = RiskConstants.Continents.Africa }},
                    {22, new Country { Name = RiskConstants.Countries.NorthAfrica, Continent = RiskConstants.Continents.Africa }},
                    {23, new Country { Name = RiskConstants.Countries.EastAfrica, Continent = RiskConstants.Continents.Africa }},
                    {24, new Country { Name = RiskConstants.Countries.Congo, Continent = RiskConstants.Continents.Africa }},
                    {25, new Country { Name = RiskConstants.Countries.SouthAfrica, Continent = RiskConstants.Continents.Africa }},
                    {26, new Country { Name = RiskConstants.Countries.Madagascar, Continent = RiskConstants.Continents.Africa }},

                    {27, new Country { Name = RiskConstants.Countries.MiddleEast, Continent = RiskConstants.Continents.Asia }},
                    {28, new Country { Name = RiskConstants.Countries.Afghanistan, Continent = RiskConstants.Continents.Asia }},
                    {29, new Country { Name = RiskConstants.Countries.Ural, Continent = RiskConstants.Continents.Asia }},
                    {30, new Country { Name = RiskConstants.Countries.Siberia, Continent = RiskConstants.Continents.Asia }},
                    {31, new Country { Name = RiskConstants.Countries.Yakutsk, Continent = RiskConstants.Continents.Asia }},
                    {32, new Country { Name = RiskConstants.Countries.Kamchatka, Continent = RiskConstants.Continents.Asia }},
                    {33, new Country { Name = RiskConstants.Countries.Irkutsk, Continent = RiskConstants.Continents.Asia }},
                    {34, new Country { Name = RiskConstants.Countries.Mongolia, Continent = RiskConstants.Continents.Asia }},
                    {35, new Country { Name = RiskConstants.Countries.China, Continent = RiskConstants.Continents.Asia }},
                    {36, new Country { Name = RiskConstants.Countries.Japan, Continent = RiskConstants.Continents.Asia }},
                    {37, new Country { Name = RiskConstants.Countries.India, Continent = RiskConstants.Continents.Asia }},
                    {38, new Country { Name = RiskConstants.Countries.Siam, Continent = RiskConstants.Continents.Asia }},

                    {39, new Country { Name = RiskConstants.Countries.Indonesia, Continent = RiskConstants.Continents.Australia }},
                    {40, new Country { Name = RiskConstants.Countries.NewGuinea, Continent = RiskConstants.Continents.Australia }},
                    {41, new Country { Name = RiskConstants.Countries.WesternAustralia, Continent = RiskConstants.Continents.Australia }},
                    {42, new Country { Name = RiskConstants.Countries.EasternAustralia, Continent = RiskConstants.Continents.Australia }},
                }
            };

            board.CountryDictionary = board.Countries.ToDictionary(x => x.Value.Name, x => x.Value);

            board.CountryDictionary[RiskConstants.Countries.Alaska].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.NorthwestTerritory],
                board.CountryDictionary[RiskConstants.Countries.Alberta],
                board.CountryDictionary[RiskConstants.Countries.Kamchatka],
            };
            board.CountryDictionary[RiskConstants.Countries.NorthwestTerritory].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Alaska],
                board.CountryDictionary[RiskConstants.Countries.Alberta],
                board.CountryDictionary[RiskConstants.Countries.Ontario],
                board.CountryDictionary[RiskConstants.Countries.Greenland],
            };
            board.CountryDictionary[RiskConstants.Countries.Greenland].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.NorthwestTerritory],
                board.CountryDictionary[RiskConstants.Countries.Ontario],
                board.CountryDictionary[RiskConstants.Countries.Quebec],
                board.CountryDictionary[RiskConstants.Countries.Iceland],
            };
            board.CountryDictionary[RiskConstants.Countries.Alberta].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Alaska],
                board.CountryDictionary[RiskConstants.Countries.NorthwestTerritory],
                board.CountryDictionary[RiskConstants.Countries.Ontario],
                board.CountryDictionary[RiskConstants.Countries.WesternUnitedStates],
            };
            board.CountryDictionary[RiskConstants.Countries.Ontario].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Alberta],
                board.CountryDictionary[RiskConstants.Countries.NorthwestTerritory],
                board.CountryDictionary[RiskConstants.Countries.Greenland],
                board.CountryDictionary[RiskConstants.Countries.Quebec],
                board.CountryDictionary[RiskConstants.Countries.EasternUnitedStates],
                board.CountryDictionary[RiskConstants.Countries.WesternUnitedStates],
            };
            board.CountryDictionary[RiskConstants.Countries.Quebec].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Ontario],
                board.CountryDictionary[RiskConstants.Countries.Greenland],
                board.CountryDictionary[RiskConstants.Countries.EasternUnitedStates],
            };
            board.CountryDictionary[RiskConstants.Countries.WesternUnitedStates].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Alberta],
                board.CountryDictionary[RiskConstants.Countries.Ontario],
                board.CountryDictionary[RiskConstants.Countries.EasternUnitedStates],
                board.CountryDictionary[RiskConstants.Countries.CentralAmerica],
            };
            board.CountryDictionary[RiskConstants.Countries.EasternUnitedStates].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.WesternUnitedStates],
                board.CountryDictionary[RiskConstants.Countries.Ontario],
                board.CountryDictionary[RiskConstants.Countries.Quebec],
                board.CountryDictionary[RiskConstants.Countries.CentralAmerica],
            };
            board.CountryDictionary[RiskConstants.Countries.CentralAmerica].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.WesternUnitedStates],
                board.CountryDictionary[RiskConstants.Countries.EasternUnitedStates],
                board.CountryDictionary[RiskConstants.Countries.Venezuela],
            };

            board.CountryDictionary[RiskConstants.Countries.Venezuela].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Peru],
                board.CountryDictionary[RiskConstants.Countries.Brazil],
                board.CountryDictionary[RiskConstants.Countries.CentralAmerica],
            };
            board.CountryDictionary[RiskConstants.Countries.Peru].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Venezuela],
                board.CountryDictionary[RiskConstants.Countries.Brazil],
                board.CountryDictionary[RiskConstants.Countries.Argentina],
            };
            board.CountryDictionary[RiskConstants.Countries.Brazil].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Venezuela],
                board.CountryDictionary[RiskConstants.Countries.Peru],
                board.CountryDictionary[RiskConstants.Countries.Argentina],
                board.CountryDictionary[RiskConstants.Countries.NorthAfrica],
            };
            board.CountryDictionary[RiskConstants.Countries.Argentina].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Peru],
                board.CountryDictionary[RiskConstants.Countries.Brazil],
            };

            board.CountryDictionary[RiskConstants.Countries.Iceland].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.GreatBritain],
                board.CountryDictionary[RiskConstants.Countries.Scandinavia],
                board.CountryDictionary[RiskConstants.Countries.Greenland],
            };
            board.CountryDictionary[RiskConstants.Countries.Scandinavia].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Iceland],
                board.CountryDictionary[RiskConstants.Countries.GreatBritain],
                board.CountryDictionary[RiskConstants.Countries.NorthernEurope],
                board.CountryDictionary[RiskConstants.Countries.Ukraine],
            };
            board.CountryDictionary[RiskConstants.Countries.GreatBritain].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Iceland],
                board.CountryDictionary[RiskConstants.Countries.Scandinavia],
                board.CountryDictionary[RiskConstants.Countries.NorthernEurope],
                board.CountryDictionary[RiskConstants.Countries.WesternEurope],
            };
            board.CountryDictionary[RiskConstants.Countries.NorthernEurope].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Iceland],
                board.CountryDictionary[RiskConstants.Countries.Scandinavia],
                board.CountryDictionary[RiskConstants.Countries.GreatBritain],
                board.CountryDictionary[RiskConstants.Countries.Ukraine],
                board.CountryDictionary[RiskConstants.Countries.WesternEurope],
                board.CountryDictionary[RiskConstants.Countries.SouthernEurope],
            };
            board.CountryDictionary[RiskConstants.Countries.Ukraine].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Scandinavia],
                board.CountryDictionary[RiskConstants.Countries.NorthernEurope],
                board.CountryDictionary[RiskConstants.Countries.SouthernEurope],
                board.CountryDictionary[RiskConstants.Countries.Ural],
                board.CountryDictionary[RiskConstants.Countries.Afghanistan],
                board.CountryDictionary[RiskConstants.Countries.MiddleEast],
            };
            board.CountryDictionary[RiskConstants.Countries.WesternEurope].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.GreatBritain],
                board.CountryDictionary[RiskConstants.Countries.NorthernEurope],
                board.CountryDictionary[RiskConstants.Countries.SouthernEurope],
                board.CountryDictionary[RiskConstants.Countries.NorthAfrica],
            };

            board.CountryDictionary[RiskConstants.Countries.Egypt].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.NorthAfrica],
                board.CountryDictionary[RiskConstants.Countries.EastAfrica],
                board.CountryDictionary[RiskConstants.Countries.SouthernEurope],
                board.CountryDictionary[RiskConstants.Countries.MiddleEast],
            };
            board.CountryDictionary[RiskConstants.Countries.NorthAfrica].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Egypt],
                board.CountryDictionary[RiskConstants.Countries.EastAfrica],
                board.CountryDictionary[RiskConstants.Countries.Congo],
                board.CountryDictionary[RiskConstants.Countries.Brazil],
            };
            board.CountryDictionary[RiskConstants.Countries.EastAfrica].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Egypt],
                board.CountryDictionary[RiskConstants.Countries.NorthAfrica],
                board.CountryDictionary[RiskConstants.Countries.Congo],
                board.CountryDictionary[RiskConstants.Countries.Madagascar],
                board.CountryDictionary[RiskConstants.Countries.MiddleEast],
            };
            board.CountryDictionary[RiskConstants.Countries.Congo].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.NorthAfrica],
                board.CountryDictionary[RiskConstants.Countries.EastAfrica],
                board.CountryDictionary[RiskConstants.Countries.SouthAfrica],
            };
            board.CountryDictionary[RiskConstants.Countries.SouthAfrica].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Congo],
                board.CountryDictionary[RiskConstants.Countries.EastAfrica],
                board.CountryDictionary[RiskConstants.Countries.Madagascar],
            };
            board.CountryDictionary[RiskConstants.Countries.Madagascar].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.EastAfrica],
                board.CountryDictionary[RiskConstants.Countries.SouthAfrica],
            };

            board.CountryDictionary[RiskConstants.Countries.MiddleEast].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Afghanistan],
                board.CountryDictionary[RiskConstants.Countries.India],
                board.CountryDictionary[RiskConstants.Countries.Ukraine],
                board.CountryDictionary[RiskConstants.Countries.SouthernEurope],
                board.CountryDictionary[RiskConstants.Countries.Egypt],
                board.CountryDictionary[RiskConstants.Countries.EastAfrica],
            };
            board.CountryDictionary[RiskConstants.Countries.Afghanistan].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.MiddleEast],
                board.CountryDictionary[RiskConstants.Countries.India],
                board.CountryDictionary[RiskConstants.Countries.China],
                board.CountryDictionary[RiskConstants.Countries.Ural],
                board.CountryDictionary[RiskConstants.Countries.Ukraine],
            };
            board.CountryDictionary[RiskConstants.Countries.Ural].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Afghanistan],
                board.CountryDictionary[RiskConstants.Countries.China],
                board.CountryDictionary[RiskConstants.Countries.Siberia],
                board.CountryDictionary[RiskConstants.Countries.Ukraine],
            };
            board.CountryDictionary[RiskConstants.Countries.Siberia].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Ural],
                board.CountryDictionary[RiskConstants.Countries.China],
                board.CountryDictionary[RiskConstants.Countries.Mongolia],
                board.CountryDictionary[RiskConstants.Countries.Irkutsk],
                board.CountryDictionary[RiskConstants.Countries.Yakutsk],
            };
            board.CountryDictionary[RiskConstants.Countries.Yakutsk].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Siberia],
                board.CountryDictionary[RiskConstants.Countries.Irkutsk],
                board.CountryDictionary[RiskConstants.Countries.Kamchatka],
            };
            board.CountryDictionary[RiskConstants.Countries.Kamchatka].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Yakutsk],
                board.CountryDictionary[RiskConstants.Countries.Irkutsk],
                board.CountryDictionary[RiskConstants.Countries.Mongolia],
                board.CountryDictionary[RiskConstants.Countries.Japan],
                board.CountryDictionary[RiskConstants.Countries.Alaska],
            };
            board.CountryDictionary[RiskConstants.Countries.Irkutsk].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Yakutsk],
                board.CountryDictionary[RiskConstants.Countries.Kamchatka],
                board.CountryDictionary[RiskConstants.Countries.Mongolia],
                board.CountryDictionary[RiskConstants.Countries.Siberia],
            };
            board.CountryDictionary[RiskConstants.Countries.Mongolia].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Irkutsk],
                board.CountryDictionary[RiskConstants.Countries.Kamchatka],
                board.CountryDictionary[RiskConstants.Countries.Japan],
                board.CountryDictionary[RiskConstants.Countries.China],
                board.CountryDictionary[RiskConstants.Countries.Siberia],
            };
            board.CountryDictionary[RiskConstants.Countries.China].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Afghanistan],
                board.CountryDictionary[RiskConstants.Countries.Ural],
                board.CountryDictionary[RiskConstants.Countries.Siberia],
                board.CountryDictionary[RiskConstants.Countries.Mongolia],
                board.CountryDictionary[RiskConstants.Countries.Siam],
                board.CountryDictionary[RiskConstants.Countries.India],
            };
            board.CountryDictionary[RiskConstants.Countries.Japan].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Kamchatka],
                board.CountryDictionary[RiskConstants.Countries.Mongolia],
            };
            board.CountryDictionary[RiskConstants.Countries.India].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.MiddleEast],
                board.CountryDictionary[RiskConstants.Countries.Afghanistan],
                board.CountryDictionary[RiskConstants.Countries.China],
                board.CountryDictionary[RiskConstants.Countries.Siam],
            };
            board.CountryDictionary[RiskConstants.Countries.Siam].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.India],
                board.CountryDictionary[RiskConstants.Countries.China],
                board.CountryDictionary[RiskConstants.Countries.Indonesia],
            };

            board.CountryDictionary[RiskConstants.Countries.Indonesia].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Siam],
                board.CountryDictionary[RiskConstants.Countries.NewGuinea],
                board.CountryDictionary[RiskConstants.Countries.WesternAustralia],
            };
            board.CountryDictionary[RiskConstants.Countries.NewGuinea].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Indonesia],
                board.CountryDictionary[RiskConstants.Countries.EasternAustralia],
                board.CountryDictionary[RiskConstants.Countries.WesternAustralia],
            };
            board.CountryDictionary[RiskConstants.Countries.WesternAustralia].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.Indonesia],
                board.CountryDictionary[RiskConstants.Countries.EasternAustralia],
                board.CountryDictionary[RiskConstants.Countries.NewGuinea],
            };
            board.CountryDictionary[RiskConstants.Countries.EasternAustralia].AdjacentCountries = new List<Country>
            {
                board.CountryDictionary[RiskConstants.Countries.WesternAustralia],
                board.CountryDictionary[RiskConstants.Countries.NewGuinea],
            };

            return board;
        }
    }
}
