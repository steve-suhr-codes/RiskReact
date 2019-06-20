using System;
using System.Collections.Generic;
using System.Text;

namespace Risk
{
    public enum GamePhase
    {
        Pending,
        Claim,
        Place,
        Play,
        Finished
    }

    public enum TurnPhase
    {
        None,
        GainArmies,
        Attack,
        Fortify
    }

    public enum CardType
    {
        Soldier,
        Calvalry,
        Artillery
    }

    public enum PlayerColor
    {
        None,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }

}
