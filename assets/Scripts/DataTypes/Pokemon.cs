namespace DataTypes
{
    public class Pokemon
    {
        private string _name;
        private string _idNumber;
        private string _playerName;
        private string _spritePath;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string IDNumber
        {
            get => _idNumber;
            private set => _idNumber = value;
        }

        public string PlayerName
        {
            get => _playerName;
            private set => _playerName = value;
        }

        public Pokemon(string pokemonName, string playerName)
        {
            _name = pokemonName;
            _playerName = playerName;
        }
    }
}