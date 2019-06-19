using System.Collections.Generic;

namespace Risk.Models
{
    public class Table
    {
        public Board Board { get; set; }
        public List<Player> Players { get; set; }
        public int CurrentTurnIndex { get; set; }

        public Player CurrentPlayer => Players[CurrentTurnIndex];

        public void NextTurn()
        {
            CurrentTurnIndex = (CurrentTurnIndex + 1) % Players.Count;
        }
    }
}
