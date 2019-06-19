using RiskReact.Models.Entities;

namespace RiskReact.Services.Interfaces
{
    public interface ICountryClaimer
    {
        bool ClaimCountry(Player player, Board board);
    }
}
