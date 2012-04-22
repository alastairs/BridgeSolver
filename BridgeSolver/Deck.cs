using System;
using System.Collections;
using System.Collections.Generic;
using BridgeSolver.Cards;

namespace BridgeSolver
{
    public class Deck : IEnumerable<Card>
    {
        private readonly List<Card> _deck;

        public Deck()
        {
            _deck = new List<Card>(52);
            PrepareDeck();
        }

        private void PrepareDeck()
        {
            CreateCards(_deck);
            Shuffle(_deck);

            return;
        }

        private static void CreateCards(ICollection<Card> deck)
        {
            for (var suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (var rank = Rank.Two; rank <= Rank.Ace; rank++)
                {
                    deck.Add(new Card(rank, suit));
                }
            }
        }

        private static void Shuffle(IList<Card> deck)
        {
            var rand = new Random();

            for (var i = 0; i < 100; i++)
            {
                var first = rand.Next(0, 51);
                var second = rand.Next(0, 51);

                var temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _deck.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
