using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjects.DataTypes
{
    [CreateAssetMenu(fileName = "PokemonDatabase", menuName = "Pokemon/Create Pokemon Database", order = 1)]
    public class PokemonDatabase : ScriptableObject
    {
        [SerializeField]
        public List<PokemonData> _allPokemon;

        
        public PokemonDatabase()
        {
            _allPokemon = new List<PokemonData>();
        }
        
        public List<PokemonData> AllPokemon
        {
            get => _allPokemon;
            set => _allPokemon = value;
        }

        public void Add(PokemonData pokemonData)
        {
            _allPokemon ??= new List<PokemonData>();
            _allPokemon.Add(pokemonData);
        }

        public void Clear()
        {
            _allPokemon.Clear();
        }

        public PokemonData GetPokemon(string pokemonName)
        {
            return _allPokemon.FirstOrDefault(pokemonData => pokemonData.name == pokemonName);
        }
        
        public PokemonData GetPokemon(int pokemonNumber)
        {
            return _allPokemon.FirstOrDefault(pokemonData => pokemonData.id == pokemonNumber);
        }
    }
}
