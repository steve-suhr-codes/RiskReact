using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class RandomCountryClaimer : ICountryClaimer
    {
        public bool ClaimCountry(Player player, Board board)
        {
            var availableCountries = board.GetUnclaimedCountries();

            if (availableCountries.Count == 0)
                return false;

            var chosenCountry = availableCountries[0];

            player.ClaimCountry(chosenCountry);

            return true;
        }
    }
}
