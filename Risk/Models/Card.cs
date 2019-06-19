namespace Risk.Models
{
    public enum CardType
    {
        Soldier,
        Calvalry,
        Artillery
    }

    public class Card
    {
        public string CountryName { get; set; }
        public CardType CardType { get; set; }
    }
}
