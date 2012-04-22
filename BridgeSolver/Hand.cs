using System.Collections;
using System.Collections.Generic;
using BridgeSolver.Cards;
using System.Linq;

namespace BridgeSolver
{
    public class Hand : ICollection<Card>
    {
        private readonly List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }

        public int Points
        {
            get { return _cards.Sum(c => c.PointsValue); }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public bool Contains(Card card)
        {
            return _cards.Contains(card);
        }

        public void CopyTo(Card[] array, int arrayIndex)
        {
            _cards.CopyTo(array, arrayIndex);
        }

        public bool Remove(Card item)
        {
            return _cards.Remove(item);
        }

        public int Count
        {
            get { return _cards.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}