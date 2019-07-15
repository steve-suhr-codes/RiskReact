using System.Linq;
using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class SmartCountryClaimer1 : ICountryClaimer
    {
        private ICountryClaimer _defaultCountryClaimer = new RandomCountryClaimer();

        public bool ClaimCountry(Player player, Board board)
        {
            var continentsToWatchOutFor = board.GetContinentsOtherPlayersCanGet(player.Name);

            var continentsToKeepFromOthers = continentsToWatchOutFor
                .Where(x => x.CountriesLeftToClaim.Count == 1).ToList();

            if (continentsToKeepFromOthers.Any())
            {
                player.Ledger.Log($"Player {player.Name} wants to keep another player from getting a continent.");

                var chosenCountry = continentsToKeepFromOthers.First().CountriesLeftToClaim.First();
                player.ClaimCountry(chosenCountry);

                player.Ledger.Log($"Player {player.Name} has claimed {chosenCountry.Name}.");
                return true;
            }

            var continentsImWorkingOn = board.GetContinentsPlayerCanGet(player.Name);
            if (continentsImWorkingOn.Any())
            {
                player.Ledger.Log($"Player {player.Name} wants to claim a continent.");

                var bestContinentToGet = continentsImWorkingOn
                    .OrderBy(x => x.CountriesLeftToClaim.Count).First();
                var chosenCountry = bestContinentToGet.CountriesLeftToClaim.First();
                player.ClaimCountry(chosenCountry);
                player.Ledger.Log($"Player {player.Name} has claimed {chosenCountry.Name}.");

                player.Ledger.Log($"Player {player.Name} has claimed {chosenCountry.Name}.");
                return true;
            }

            return _defaultCountryClaimer.ClaimCountry(player, board);
        }
    }
}
