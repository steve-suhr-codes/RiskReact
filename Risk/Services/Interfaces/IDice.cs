using Risk.Models;

namespace Risk.Services.Interfaces
{
    public interface IDice
    {
        RollResult Roll(Attack attack);
    }
}
