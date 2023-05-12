using UnityEngine;

namespace DataTypes
{
    public class Match
    {
        // Previous matches are those whose winners take part in this match
        public Match PreviousMatch1;
        public Match PreviousMatch2;
        
        // Next match is where the winner of this match will battle next
        public Match NextMatch;
        
        private int _id;
        private bool _isAvailable;
        private bool _isComplete;
        private Pokemon _pokemon1;
        private Pokemon _pokemon2;
        private Pokemon _winner;
        private int _round;

        public int ID => _id;

        public bool IsAvailable => _isAvailable;

        public bool IsComplete => _isComplete;

        public Pokemon Pokemon1 => _pokemon1;

        public Pokemon Pokemon2 => _pokemon2;

        public Pokemon Winner => _winner;

        public int Round => _round;

        public Match(Pokemon pokemon1, Pokemon pokemon2, int roundNumber, int matchID)
        {
            _pokemon1 = pokemon1;
            _pokemon2 = pokemon2;
            _round = roundNumber;
            _id = matchID;
        }
        
        public Match(int roundNumber, int matchID)
        {
            _pokemon1 = null;
            _pokemon2 = null;
            _round = roundNumber;
            _id = matchID;
        }

        public void SimulateMatch()
        {
            // TODO
            Debug.Log("Simulating match");
        }

        public int NextMatchId()
        {
            if (NextMatch != null)
            {
                return NextMatch.ID;
            }

            return -1;
        }
    }
    
}