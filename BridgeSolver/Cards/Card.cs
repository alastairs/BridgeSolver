using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgeSolver.Cards
{
    public struct Card : IComparable<Card>, IEquatable<Card>
    {
        private static readonly Dictionary<char, Suit> SuitLookup = new Dictionary<char, Suit>(4) { { 'C', Suit.Clubs }, { 'H', Suit.Hearts }, { 'D', Suit.Diamonds }, { 'S', Suit.Spades } };
        private static readonly Dictionary<char, Rank> RankLookup = new Dictionary<char, Rank>(5) { { 'T', Rank.Ten }, { 'J', Rank.Jack }, { 'Q', Rank.Queen }, { 'K', Rank.King }, { 'A', Rank.Ace } };

        public readonly Rank Rank;
        public readonly Suit Suit;

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int PointsValue { get { return Math.Max(0, (int)Rank - 10); } }

        public static Card Create(string spec)
        {
            Rank rank;
            char rankSpec = spec[0];
            char suitSpec = spec[1];

            if (char.IsDigit(rankSpec))
            {
                rank = (Rank)int.Parse(rankSpec.ToString());
            }
            else
            {
                rank = RankLookup[rankSpec];
            }

            var suit = SuitLookup[suitSpec];
            return new Card(rank, suit);
        }

        public int CompareTo(Card other)
        {
            return Rank.CompareTo(other.Rank);
        }

        public bool Equals(Card other)
        {
            return Rank.Equals(other.Rank) && Suit.Equals(other.Suit);
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                var card2 = (Card)obj;
                return Rank == card2.Rank && Suit == card2.Suit;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Rank.GetHashCode() * Suit.GetHashCode();
        }

        public override string ToString()
        {
            Rank rank = Rank;

            char rankChar;
            if (RankLookup.ContainsValue(rank))
            {
                rankChar = RankLookup.Single(r => r.Value == rank).Key;
            }
            else
            {
                rankChar = ((int)Rank).ToString().First();
            }

            return string.Format("{0}{1}", rankChar, Suit.ToString().First());
        }
    }
}