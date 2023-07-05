using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace DataTypes
{
    [CreateAssetMenu(fileName = "PokemonDatabase", menuName = "Pokemon/Create Pokemon Database", order = 1)]
    public class PokemonDatabase : ScriptableObject
    {
        [SerializeField]
        private List<PokemonData> allPokemon;

        public List<PokemonData> AllPokemon => allPokemon;
        
        // A hacky way to store the active generations
        public List<bool> activeGenerations;

        // A hacky way to store the generation ranges
        public List<int> generationRangesStart;
        public List<int> generationRangesEnd;

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
            var randomIndex = GetPokemonIndexInActiveGeneration();
            var randomPokemon = GetPokemon(randomIndex);
            if (randomPokemon != null)
                return randomPokemon;
            else
            {
                Debug.LogError("PokemonDatabase: GetRandomPokemon: randomPokemon is null with index: " + randomIndex);
                return GetRandomPokemon();
            }
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

        private int GetPokemonIndexInActiveGeneration()
        {
            int totalWidth = 0;
                
            // Compute the total width of all ranges
            for (int i = 0; i < activeGenerations.Count; i++)
            {
                if (!activeGenerations[i])
                    continue;
                totalWidth += generationRangesEnd[i] - generationRangesStart[i] + 1;
            }

            // Get a random value within the total width
            int randomValue = Random.Range(1, totalWidth);

            // Find the range that contains the random value
            for (int i = 0; i < activeGenerations.Count; i++)
            {
                if (!activeGenerations[i])
                    continue;
                if (randomValue <= (generationRangesEnd[i] - generationRangesStart[i]))
                    return generationRangesStart[i] + randomValue;
                else
                    randomValue -= (generationRangesEnd[i] - generationRangesStart[i] + 1);
            }

            Debug.LogError("Should not reach here");
            return -1;
        }
    }
}
