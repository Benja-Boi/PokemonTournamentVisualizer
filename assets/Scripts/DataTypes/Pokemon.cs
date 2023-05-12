using DefaultNamespace;
using ScriptableObjects.DataTypes;
using UnityEngine;

namespace DataTypes
{
    public class Pokemon
    {
        private PokemonData _data;

        public string Name { get; private set; }

        public string PlayerName { get; private set; }
        
        public Sprite Sprite => _data.sprite;

        public Pokemon(string playerName, string pokemonName)
        {
            Name = pokemonName;
            PlayerName = playerName;
            _data = PokemonDataManager.Instance.GetPokemon(pokemonName);
        }
    }
}