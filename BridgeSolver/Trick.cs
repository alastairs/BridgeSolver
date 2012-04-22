using System.Text;
using BridgeSolver.Players;

namespace BridgeSolver
{
    public class Trick
    {
        public Player Lead { get; private set; }
        public CardsPlayedCollection CardsPlayed { get; private set; }
        public Player Winner { get; private set; }

        public Trick(Player lead, CardsPlayedCollection cardsPlayed, Player winner)
        {
            Lead = lead;
            CardsPlayed = cardsPlayed;
            Winner = winner;
        }

        public override string ToString()
        {
            const string separator = ", ";
            var stringBuilder = new StringBuilder();

            foreach (var cardPlayed in CardsPlayed)
            {
                stringBuilder.AppendFormat("{0} = {1}{2}", cardPlayed.Player, cardPlayed.Card, separator);
            }

            return stringBuilder.ToString(0, stringBuilder.Length - separator.Length);
        }
    }
}