using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace DataTypes
{
    [CreateAssetMenu(fileName = "PokemonDatabase", menuName = "Pokemon/Create Pokemon Database", order = 1)]
    public class PokemonDatabase : ScriptableObject
    {
        [SerializeField]
        private List<PokemonData> allPokemon;

        public List<PokemonData> AllPokemon => allPokemon;
        private int maxPokemonIndex = 0;

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

        private PokemonData GetRandomPokemon()
        {
            return GetPokemon(Random.Range(1, GetMaxPokemonIndex()));
        }
        
        public string GetRandomPokemonName()
        {
            return GetRandomPokemon().pokemonName;
        }
        
        private int GetMaxPokemonIndex()
        {
            if (maxPokemonIndex == 0)
            {
                // iterate over allPokemon and find the highest index
                maxPokemonIndex = allPokemon.Select(pokemon => pokemon.id).Prepend(0).Max();
            }

            return maxPokemonIndex;
        }
    }
}
