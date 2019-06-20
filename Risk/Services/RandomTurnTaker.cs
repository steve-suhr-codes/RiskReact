using System.Collections.Generic;
using System.Linq;
using Risk.Models;
using Risk.Services.Interfaces;

namespace Risk.Services
{
    public class RandomTurnTaker : ITurnTaker
    {
        private IDice _dice { get; set; }

        public RandomTurnTaker(IDice dice)
        {
            _dice = dice;
        }

        public void Attack(Player player)
        {
            var nextAttack = GetNextAttack(player);
            while (nextAttack != null)
            {
                var result = _dice.Roll(nextAttack);
                if (result.AttackSucceeded)
                {
                    player.ConquerCountry(nextAttack.Attacker, nextAttack.Defender, nextAttack.Attacker.OccupyingArmyCount - 1);
                }

                nextAttack = null;
                //nextAttack = GetNextAttack(player);
            }
        }

        public Attack GetNextAttack(Player player)
        {
            var countriesThatCanAttack = player.Countries
                .Where(x => x.OccupyingArmyCount > 1 &&
                            x.AdjacentCountries.Any(c => c.OccupyingPlayer.Name != player.Name))
                .ToList();

            var battleOptions = new List<Attack>();
            foreach (var attacker in countriesThatCanAttack)
            {
                foreach (var defender in attacker.AdjacentCountries
                    .Where(c => c.OccupyingPlayer.Name != player.Name))
                {
                    var attack = new Attack
                    {
                        Attacker = attacker,
                        Defender = defender
                    };

                    battleOptions.Add(attack);
                }
            }

            var maxAdvantage = battleOptions.Max(x => x.AttackerAdvantage);
            if (maxAdvantage > 3)
                return battleOptions.First(x => x.AttackerAdvantage == maxAdvantage);

            return null;
        }
    }
}
