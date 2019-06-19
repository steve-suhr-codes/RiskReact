using Risk.Models;

namespace Risk.Services.Interfaces
{
    public interface ITroopReenforcer
    {
        bool Reenforce(Player player, int armiesToDrop);
    }
}
