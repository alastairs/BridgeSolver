using BridgeSolver.Cards;
using BridgeSolver.Logging;
using BridgeSolver.Players;
using BridgeSolver.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgeSolver.Tests
{
    [TestClass]
    public class TestGameDetermineWinner
    {
        private readonly ILogger logger;

        private readonly Player player1InContract;
        private readonly Player player2InContract;
        private readonly Player player1NotInContract;
        private readonly Player player2NotInContract;
        
        private readonly Team teamInContract;
        private readonly Team teamNotInContract;

        private Contract contract;
        
        private Game game;

        public TestGameDetermineWinner()
        {
            logger = new NoopLogger();

            // Generation of players has been moved out of Game, so this logic 
            // is duplicated in these tests and the Program class.
            player1InContract = new NaiveFirstCardPlayer(string.Empty);
            player2InContract = new NaiveFirstCardPlayer(string.Empty);

            player1NotInContract = new NaiveFirstCardPlayer(string.Empty);
            player2NotInContract = new NaiveFirstCardPlayer(string.Empty);

            player1InContract.Next = player1NotInContract;
            player1NotInContract.Next = player2InContract;
            player2InContract.Next = player2NotInContract;
            player2NotInContract.Next = player1InContract;

            teamInContract = new Team(player1InContract, player2InContract);
            teamNotInContract = new Team(player1NotInContract, player2NotInContract);

            contract = new Contract(teamInContract, 1, Suit.Spades);

            game = new Game(new[] { teamInContract, teamNotInContract }, contract, new Deck(), logger);
        }

        [TestMethod]
        public void ShouldReturnPlayerWithHighestCard_WhenSuitsAreEqual_AndTheLeadSuitIsNotTrumps()
        {
            var winner = player1InContract;
            var cardsPlayed = new CardsPlayedCollection
                                  {
                                      new CardPlayed(player2InContract, new Card(Rank.Three, Suit.Clubs)),
                                      new CardPlayed(player1NotInContract, new Card(Rank.Five, Suit.Clubs)),
                                      new CardPlayed(winner, new Card(Rank.King, Suit.Clubs)),
                                      new CardPlayed(player2NotInContract, new Card(Rank.Two, Suit.Clubs))
                                  };

            Assert.AreEqual(winner, game.DetermineWinner(cardsPlayed));
        }

        [TestMethod]
        public void ShouldReturnPlayerWithHighestCard_WhenSuitsAreEqual_AndTheLeadSuitIsTrumps()
        {
            var winner = player1InContract;
            var cardsPlayed = new CardsPlayedCollection
                                  {
                                      new CardPlayed(player2InContract, new Card(Rank.Three, Suit.Clubs)),
                                      new CardPlayed(player1NotInContract, new Card(Rank.Five, Suit.Clubs)),
                                      new CardPlayed(winner, new Card(Rank.King, Suit.Clubs)),
                                      new CardPlayed(player2NotInContract, new Card(Rank.Two, Suit.Clubs))
                                  };

            Assert.AreEqual(winner, game.DetermineWinner(cardsPlayed));
        }

        [TestMethod]
        public void ShouldReturnPlayerWithHighestCard_WhenThereIsADiscard_AndTheLeadSuitIsNotTrumps()
        {
            var winner = player1InContract;
            var cardsPlayed = new CardsPlayedCollection
                                  {
                                      new CardPlayed(player2InContract, new Card(Rank.Three, Suit.Clubs)),
                                      new CardPlayed(player1NotInContract, new Card(Rank.Five, Suit.Diamonds)),
                                      new CardPlayed(winner, new Card(Rank.King, Suit.Clubs)),
                                      new CardPlayed(player2NotInContract, new Card(Rank.Two, Suit.Clubs))
                                  };

            Assert.AreEqual(winner, game.DetermineWinner(cardsPlayed));
        }

        [TestMethod]
        public void ShouldReturnPlayerWithTrumpCard_WhenTheLeadSuitIsNotTrumps()
        {
            var winner = player1InContract;
            var cardsPlayed = new CardsPlayedCollection
                                  {
                                      new CardPlayed(player2InContract, new Card(Rank.Three, Suit.Clubs)),
                                      new CardPlayed(player1NotInContract, new Card(Rank.King, Suit.Clubs)),
                                      new CardPlayed(winner, new Card(Rank.Four, Suit.Spades)),
                                      new CardPlayed(player2NotInContract, new Card(Rank.Two, Suit.Clubs))
                                  };

            Assert.AreEqual(winner, game.DetermineWinner(cardsPlayed));
        }

        [TestMethod]
        public void ShouldReturnPlayerWithHighestTrumpCard_WhenTheLeadSuitIsNotTrumps_AndMultiplePlayersPlayTrumps()
        {
            var winner = player1InContract;
            var cardsPlayed = new CardsPlayedCollection
                                  {
                                      new CardPlayed(player2InContract, new Card(Rank.Three, Suit.Clubs)),
                                      new CardPlayed(player1NotInContract, new Card(Rank.Four, Suit.Spades)),
                                      new CardPlayed(winner, new Card(Rank.King, Suit.Spades)),
                                      new CardPlayed(player2NotInContract, new Card(Rank.Two, Suit.Clubs))
                                  };

            Assert.AreEqual(winner, game.DetermineWinner(cardsPlayed));
        }
    }
}
