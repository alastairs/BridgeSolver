using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BridgeSolver.Cards;
using BridgeSolver.Players;

namespace BridgeSolver
{
    public class CardsPlayedCollection : ICollection<CardPlayed>
    {
        private readonly ICollection<CardPlayed> _cardsPlayed = new List<CardPlayed>(); 

        public Card this[Player player]
        {
            get { return _cardsPlayed.Single(cp => cp.Player == player).Card; }
        }

        public void Add(CardPlayed cardPlayed)
        {
            _cardsPlayed.Add(cardPlayed);
        }

        public void Clear()
        {
            _cardsPlayed.Clear();
        }

        public bool Contains(CardPlayed cardPlayed)
        {
            return _cardsPlayed.Contains(cardPlayed);
        }

        public void CopyTo(CardPlayed[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(CardPlayed item)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        public IEnumerable<Player> Players
        {
            get { return _cardsPlayed.Select(cp => cp.Player); }
        }

        public IEnumerable<Card> Cards
        {
            get { return _cardsPlayed.Select(cp => cp.Card); }
        }

        public IEnumerator<CardPlayed> GetEnumerator()
        {
            return _cardsPlayed.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}