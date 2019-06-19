using Risk.Models;
using Risk.Services.Interfaces;
using System.Linq;

namespace Risk.Services
{
    public class RandomCountryClaimer : ICountryClaimer
    {
        public bool ClaimCountry(Player player, Board board)
        {
            var availableCountries = board.Countries
                .Where(x => x.Value.OccupyingPlayer == null)
                .Select(x => x.Value).ToList();

            if (availableCountries.Count == 0)
                return false;

            var chosenCountry = availableCountries[0];

            chosenCountry.OccupyingPlayer = player;
            player.DropArmies(chosenCountry, 1);

            return true;
        }
    }
}
