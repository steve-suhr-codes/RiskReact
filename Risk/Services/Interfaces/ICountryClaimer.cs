using Risk.Models;

namespace Risk.Services.Interfaces
{
    public interface ICountryClaimer
    {
        bool ClaimCountry(Player player, Board board);
    }
}
