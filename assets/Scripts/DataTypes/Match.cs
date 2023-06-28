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

        public Match(Pokemon pokemon1, Pokemon pokemon2, int roundNumber, int matchID, bool isAvailable)
        {
            _pokemon1 = pokemon1;
            _pokemon2 = pokemon2;
            _round = roundNumber;
            _id = matchID;
            _isAvailable = isAvailable;
            _isComplete = false;
        }
        
        public Match(int roundNumber, int matchID, bool isAvailable)
        {
            _pokemon1 = null;
            _pokemon2 = null;
            _round = roundNumber;
            _id = matchID;
            _isAvailable = isAvailable;
            _isComplete = false;
        }

        public void SimulateMatch()
        {
            Debug.Log("Simulating match");
            bool coinToss = Random.Range(0, 1) > 0.5f;
            Pokemon winner = coinToss ? _pokemon1 : _pokemon2;
            _winner = _pokemon1;
            if (NextMatch._pokemon1 == null)
            {
                NextMatch._pokemon1 = winner;
            }
            else
            {
                NextMatch._pokemon2 = winner;
                NextMatch._isAvailable = true;
            }

            _isAvailable = false;
            _isComplete = true;
        }

        public void SetWinner(bool player1Won)
        {
            Pokemon winner = player1Won ? _pokemon1 : _pokemon2;
            _winner = winner;
            
            if (NextMatch != null)
            {
                if (NextMatch._pokemon1 == null)
                {
                    NextMatch._pokemon1 = winner;
                }
                else
                {
                    NextMatch._pokemon2 = winner;
                    NextMatch._isAvailable = true;
                }
            }
            
            _isAvailable = false;
            _isComplete = true;
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