using System;
using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class EvenDice : IDice
    {
        public RollResult Roll(Attack attack)
        {
            var isWinner = false;
            var loses = attack.Attacker.OccupyingArmyCount - 1;

            if (attack.Attacker.OccupyingArmyCount - 1 > attack.Defender.OccupyingArmyCount)
            {
                //attacker wins
                isWinner = true;
                loses = attack.Defender.OccupyingArmyCount;

            }

            attack.Attacker.OccupyingArmyCount -= loses;
            attack.Defender.OccupyingArmyCount -= loses;

            return new RollResult
            {
                AttackSucceeded = isWinner,
                AttackerLoses = loses,
                DefenderLoses = loses
            };
        }
    }
}
