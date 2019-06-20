namespace Risk.Models
{
    public class Attack
    {
        public Country Attacker { get; set; }
        public Country Defender { get; set; }

        public int AttackerAdvantage => Attacker.OccupyingArmyCount - Defender.OccupyingArmyCount;
    }
}
