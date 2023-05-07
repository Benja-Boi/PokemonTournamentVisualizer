namespace DataTypes
{
    public class Match
    {
        public Match PreviousMatch1;
        public Match PreviousMatch2;
        public Match NextMatch;
        
        private int _id;
        private bool _isAvailable;
        private bool _isComplete;
        private Pokemon _pokemon1;
        private Pokemon _pokemon2;
        private Pokemon _winner;
        private int _round;

        public Match PreviousMatch3 => PreviousMatch1;

        public Match PreviousMatch4 => PreviousMatch2;

        public Match NextMatch1 => NextMatch;

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

        public void SimulateMatch()
        {
            // TODO
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