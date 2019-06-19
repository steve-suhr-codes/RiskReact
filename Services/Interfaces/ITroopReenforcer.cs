using RiskReact.Models.Entities;

namespace RiskReact.Services.Interfaces
{
    public interface ITroopReenforcer
    {
        bool Reenforce(Player player, int armiesToDrop);
    }
}
