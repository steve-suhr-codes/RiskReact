using System;
using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class EvenDice : IDice
    {
        private Logger _logger { get; set; }

        public EvenDice(Logger logger)
        {
            _logger = logger;
        }
        public RollResult Roll(Attack attack)
        {
            var isWinner = false;
            var loses = attack.Attacker.OccupyingArmyCount - 1;

            if (attack.Attacker.OccupyingArmyCount - 1 > attack.Defender.OccupyingArmyCount)
            {
                //attacker wins
                isWinner = true;
                loses = attack.Defender.OccupyingArmyCount;
                _logger.LogLine($"* {attack.Attacker.OccupyingPlayer.Name} ({attack.Attacker.Name}) defeats {attack.Defender.OccupyingPlayer.Name} ({attack.Defender.Name}).  {loses} armies lost on both sides");
            }
            else
            {
                _logger.LogLine($"* {attack.Attacker.OccupyingPlayer.Name} ({attack.Attacker.Name}) LOST when attacking {attack.Defender.OccupyingPlayer.Name} ({attack.Defender.Name}).  {loses} armies lost on both sides");
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
