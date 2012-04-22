using System;
using System.Collections.Generic;
using System.Linq;
using BridgeSolver.Cards;
using BridgeSolver.Logging;
using BridgeSolver.Players;

namespace BridgeSolver
{
    class Program
    {
        static void Main()
        {
            for (var i = 0; i < 10; i++)
            {
                // This is all hard-coded
                var teams = GenerateTeams();
                var contract = new Contract(teams.First(), 1, Suit.Spades);
                var game = new Game(teams, contract, new Deck(), new ConsoleLogger());
                game.Play();
                Console.ReadLine();
            }
        }

        private static IList<Team> GenerateTeams()
        {
            var north = new NaiveFirstCardPlayer("North");
            var west = new NaiveFirstCardPlayer("West") { Next = north };
            var south = new NaiveFirstCardPlayer("South") { Next = west };
            var east = new NaiveFirstCardPlayer("East") { Next = south };
            north.Next = east;

            return new List<Team> { new Team(north, south), new Team(east, west) };
        }
    }
}
