using System.Linq;
using BridgeSolver.Cards;

namespace BridgeSolver.Players
{
    /// <summary>
    /// This <see cref="Player"/> will lead trumps whilst it still has them.
    /// </summary>
    public class JonsFirstRulePlayer : Player, IDeclarer
    {
        private int _trumpsPlayed;

        public JonsFirstRulePlayer(string name, bool isDeclarer)
            : base(name, isDeclarer)
        {
           
        }

        protected override Card PlayCard(CardsPlayedCollection cardsPlayed)
        {
            if (!cardsPlayed.Any() && IsDeclarer)
            {
                
            }

            if (cardsPlayed.Any() && CanFollowSuit(cardsPlayed.First().Card))
            {
                var card = Hand.First(c => c.Suit == cardsPlayed.First().Card.Suit);
                return card;
            }

            return Hand.First();
        }
    }

    public interface IDeclarer
    {
        Card PlayDummyCard();
    }
}