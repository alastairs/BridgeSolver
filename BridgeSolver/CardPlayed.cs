using BridgeSolver.Cards;
using BridgeSolver.Players;

namespace BridgeSolver
{
    public class CardPlayed
    {
        public Player Player { get; private set; }
        public Card Card { get; private set; }

        public CardPlayed(Player player, Card card)
        {
            Player = player;
            Card = card;
        }
    }
}