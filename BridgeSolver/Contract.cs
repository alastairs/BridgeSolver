using System.Collections.Generic;
using System.Linq;
using BridgeSolver.Cards;

namespace BridgeSolver
{
    public class Contract
    {
        public Team Team { get; private set; }

        public int Level { get; private set; }
        public Suit Suit { get; private set; }

        public Contract(Team team, int level, Suit suit)
        {
            Team = team;
            Level = level;
            Suit = suit;
        }

        public int Result
        {
            get { return Team.NumberOfTricksWon - (Level + 6); }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Level, Suit);
        }
    }
}
