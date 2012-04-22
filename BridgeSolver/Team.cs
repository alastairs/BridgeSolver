using System.Collections.Generic;
using System.Linq;
using BridgeSolver.Players;

namespace BridgeSolver
{ 
    public class Team
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public IEnumerable<Player> Players { get { return new[] {_player1, _player2}; } }

        public int NumberOfTricksWon
        {
            get { return _player1.TricksWon.Concat(_player2.TricksWon).Count(); }
        }

        public string Name { get { return _player1.Name + "-" + _player2.Name; }}
        public int Points { get {return _player1.Hand.Points + _player2.Hand.Points; }}

        public Team(Player player1, Player player2)
        {
            _player2 = player2;
            _player1 = player1;

            _player2.Partner = _player1;
            _player1.Partner = _player2;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
