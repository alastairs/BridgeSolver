using System.Linq;
using BridgeSolver.Cards;

namespace BridgeSolver.Players
{
    /// <summary>
    /// This <see cref="Player" /> simply plays the first card in its hand.  It will follow suit
    /// if it is not the leader and if it can.
    /// </summary>
    public class NaiveFirstCardPlayer : Player
    {
        public NaiveFirstCardPlayer(string name)
            : base(name)
        {
        }

        protected override Card PlayCard(CardsPlayedCollection cardsPlayed)
        {
            if (cardsPlayed.Any() && CanFollowSuit(cardsPlayed.First().Card))
            {
                var card = Hand.First(c => c.Suit == cardsPlayed.First().Card.Suit);
                return card;
            }

            return Hand.First();
        }
    }
}