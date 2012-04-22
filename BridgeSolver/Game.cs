using System;
using System.Collections.Generic;
using System.Linq;
using BridgeSolver.Cards;
using BridgeSolver.Logging;
using BridgeSolver.Players;

namespace BridgeSolver
{
    public class Game
    {
        private readonly int _numberOfPlayers;
        private readonly ILogger _logger;

        public IList<Team> Teams { get; set; }

        public Contract Contract { get; private set; }

        public Player Declarer { get; private set; }
        public Player Dummy { get; private set; }
        
        public IList<Trick> Tricks { get; set; }

        public Game(IList<Team> teams, Contract contract, IEnumerable<Card> deck, ILogger logger)
        {
            _logger = logger;
            Contract = contract;

            Teams = teams;
            _numberOfPlayers = teams.SelectMany(t => t.Players).Count();

            Declarer = Contract.Team.Players.First(); // TODO: This probably isn't right!
            Dummy = Contract.Team.Players.Last(); // TODO: This probably isn't right!

            Deal(deck, Declarer); //TODO: This Probably isn't right!
        }

        public void Play()
        {
            _logger.InfoFormat("Declarer is {0}", Declarer);
            _logger.InfoFormat("Contract is {0}", Contract);
            _logger.InfoFormat("North-South has {0} points", Teams.First().Points);
            _logger.InfoFormat("East-West has {0} points", Teams.Last().Points);

            var lead = Declarer.Next;

            PlayGame(lead);

            _logger.InfoFormat("North-South made {0} tricks", Teams.First().NumberOfTricksWon);
            _logger.InfoFormat("East-West made {0} tricks", Teams.Last().NumberOfTricksWon);

            var result = Contract.Result;
            PrintContractResult(result); 
        }

        public Player DetermineWinner(CardsPlayedCollection cardsPlayed)
        {
            var winner = cardsPlayed.First();

            foreach (var cardPlayed in cardsPlayed)
            {
                if (cardPlayed.Card.Suit == winner.Card.Suit && cardPlayed.Card.Rank > winner.Card.Rank)
                {
                    winner = cardPlayed;
                    continue;
                }

                if (cardPlayed.Card.Suit == Contract.Suit && winner.Card.Suit != Contract.Suit)
                {
                    winner = cardPlayed;
                    continue;
                }
            }

            return cardsPlayed.Single(cp => cp == winner).Player;
        }

        private void PlayGame(Player lead)
        {
            var current = lead;

            for (var i = 0; i < 13; i++)
            {
                var cardsPlayed = PlayRound(current);
                var winner = DetermineWinner(cardsPlayed);
                var trick = new Trick(lead, cardsPlayed, winner);
                
                ReviewTrick(trick);
                winner.WinTrick(trick);
                _logger.InfoFormat("{0} won trick {1} ({2}) with {3}", winner, i + 1, trick, cardsPlayed[winner]);

                current = winner;
            }
        }

        private CardsPlayedCollection PlayRound(Player current)
        {
            var cardsPlayed = new CardsPlayedCollection();

            for (var i = 0; i < _numberOfPlayers; i++)
            {
                cardsPlayed.Add(new CardPlayed(current, current.Play(cardsPlayed)));
                current = current.Next;
            }
            
            return cardsPlayed;
        }

        private void ReviewTrick(Trick trick)
        {
            var current = trick.Lead;

            for (var i = 0; i < _numberOfPlayers; i++)
            {
                current.ReviewTrick(trick);
                current = current.Next;
            }
        }

        private void PrintContractResult(int result)
        {
            if (result == 0)
            {
                _logger.InfoFormat("Contract made");
            }
            else if (result > 0)
            {
                _logger.InfoFormat("Contract up {0}", result);
            }
            else if (result < 0)
            {
                _logger.InfoFormat("Contract down {0}", Math.Abs(result));
            }
        }

        private static void Deal(IEnumerable<Card> deck, Player target)
        {
            foreach (Card t in deck)
            {
                target.AddCardToHand(t);
                target = target.Next;
            }
        }
    }
}