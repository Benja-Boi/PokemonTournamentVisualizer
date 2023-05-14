using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjects.DataTypes
{
    [CreateAssetMenu(fileName = "PokemonDatabase", menuName = "Pokemon/Create Pokemon Database", order = 1)]
    public class PokemonDatabase : ScriptableObject
    {
        [SerializeField]
        private List<PokemonData> allPokemon;

        public List<PokemonData> AllPokemon => allPokemon;


        public PokemonDatabase()
        {
            allPokemon = new List<PokemonData>();
        }

        public void Add(PokemonData pokemonData)
        {
            allPokemon ??= new List<PokemonData>();
            allPokemon.Add(pokemonData);
        }

        public void Clear()
        {
            allPokemon.Clear();
        }

        public PokemonData GetPokemon(string pokemonName)
        {
            return allPokemon.FirstOrDefault(pokemonData => pokemonData.name == pokemonName);
        }
        
        public PokemonData GetPokemon(int pokemonNumber)
        {
            return allPokemon.FirstOrDefault(pokemonData => pokemonData.id == pokemonNumber);
        }

        public PokemonData GetRandomPokemon()
        {
            return GetPokemon(Random.Range(1, allPokemon.Count));
        }
        
        public string GetRandomPokemonName()
        {
            return GetPokemon(Random.Range(1, allPokemon.Count)).pokemonName;
        }
    }
}
