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
        private int _roundNumber;

        public Match(Pokemon pokemon1, Pokemon pokemon2, int roundNumber, int matchID)
        {
            _pokemon1 = pokemon1;
            _pokemon2 = pokemon2;
            _roundNumber = roundNumber;
            _id = matchID;
        }
    }
    
}