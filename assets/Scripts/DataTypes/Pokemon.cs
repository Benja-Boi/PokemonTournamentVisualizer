using ScriptableObjects.DataTypes;
using UnityEngine;

namespace DataTypes
{
    public class Pokemon
    {
        private string _name;
        private string _playerName;
        private PokemonData _data;

        public string Name
        {
            get => _name;
            private set => _name = value;
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