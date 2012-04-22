using System.Collections.Generic;
using System.Linq;
using BridgeSolver.Cards;

namespace BridgeSolver.Players
{
    public abstract class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; set; }
        public Player Next { get; set; }
        public Player Partner { get; set; }

        private IList<Trick> _tricksWon;
        protected bool IsDeclarer { get; private set; }
        protected bool IsDummy { get; private set; }

        public IEnumerable<Trick> TricksWon
        {
            get { return _tricksWon; }
            private set { _tricksWon = value.ToList(); }
        }

        protected Player(string name, bool isDeclarer = false, bool isDummy = false)
        {
            Hand = new Hand();
            TricksWon = new List<Trick>();
            
            Name = name;
            IsDeclarer = isDeclarer;
            IsDummy = isDummy;
        }

        public Card Play(CardsPlayedCollection cardsPlayed)
        {
            var cardPlayed = PlayCard(cardsPlayed);
            Hand.Remove(cardPlayed);
            return cardPlayed;
        }

        /// <summary>
        /// Selects which card from the Player's hand should be played next, given the supplied play history.
        /// </summary>
        /// <param name="cardsPlayed">The cards played so far in the current trick</param>
        /// <returns></returns>
        protected abstract Card PlayCard(CardsPlayedCollection cardsPlayed);

        public void WinTrick(Trick trickWon)
        {
            _tricksWon.Add(trickWon);
        }

        protected bool CanFollowSuit(Card lead)
        {
            return Hand.Any(c => c.Suit == lead.Suit);
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public virtual void ReviewTrick(Trick trick)
        {
            return;
        }
    }
}