using System.Linq;
using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class SmartCountryClaimer1 : ICountryClaimer
    {
        public bool ClaimCountry(Player player, Board board)
        {
            var continentsToWatchOutFor = board.GetContinentsOtherPlayersCanGet(player.Name);

            var continentsToKeepFromOthers = continentsToWatchOutFor
                .Where(x => x.CountriesLeftToClaim.Count == 1).ToList();

            if (continentsToKeepFromOthers.Any())
            {
                var chosenCountry = continentsToKeepFromOthers.First().CountriesLeftToClaim.First();
                player.ClaimCountry(chosenCountry);
                return true;
            }



            return true;
        }
    }
}
