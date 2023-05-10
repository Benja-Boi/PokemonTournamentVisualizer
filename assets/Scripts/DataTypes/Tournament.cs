using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;

namespace DataTypes
{
    public class Tournament
    {
        private Match _finalMatch;
        public Match FinalMatch => _finalMatch;

        public Dictionary<string, Pokemon> _playerPokemons;
        
        public Tournament(List<(string playerName, string pokemonName)> playerPokemonPairs)
        {
            _playerPokemons = new Dictionary<string, Pokemon>();
            InitTournament(playerPokemonPairs);
        }

        public void InitTournament(List<(string playerName, string pokemonName)> playerPokemonPairs)
        {
            // Shuffle the player-pokemon pairs to randomize the seeding
            playerPokemonPairs.Shuffle();
            
            // Create a queue to hold the shuffled Pokemon
            Queue<Pokemon> pokemonQueue = new Queue<Pokemon>();
   
            // Enqueue the Pokemon in the shuffled order
            foreach (var newPokemon in playerPokemonPairs.Select(choice => new Pokemon(choice.Item1, choice.Item2)))
            {
                _playerPokemons[newPokemon.PlayerName] = newPokemon;
                pokemonQueue.Enqueue(newPokemon);
            }
            
            // Populate the binary tree with round 1 matches
            int matchIdCounter = 1 ;
            _finalMatch = CreateRoundMatches(pokemonQueue, 1, ref matchIdCounter);
        }
        
        private Match CreateRoundMatches(Queue<Pokemon> pokemonQueue, int roundNumber, ref int matchIdCounter)
        {
            if (pokemonQueue.Count == 0)
            {
                return null;
            }

            Pokemon pokemon1 = pokemonQueue.Dequeue();
            Pokemon pokemon2 = pokemonQueue.Count > 0 ? pokemonQueue.Dequeue() : null;

            Match match = new Match(pokemon1, pokemon2, roundNumber, matchIdCounter++);
 
            if (pokemonQueue.Count > 0)
            {
                match.PreviousMatch1.NextMatch = match;
                match.PreviousMatch2.NextMatch = match;
                match.PreviousMatch1 = CreateRoundMatches(pokemonQueue, roundNumber + 1, ref matchIdCounter);
                match.PreviousMatch2 = CreateRoundMatches(pokemonQueue, roundNumber + 1, ref matchIdCounter);
            }

            //return match;

    
        }
        
        public static Match BuildBinaryTree(List<Pokemon> pokemons)
        {
            if (pokemons == null || pokemons.Count == 0)
                return null;

            int index = 0;
            Match root = new Match(pokemons[index++]);
            Queue<Match> queue = new Queue<Match>();
            queue.Enqueue(root);

            while (index < pokemons.Count)
            {
                Match current = queue.Dequeue();

                // Assign left child
                if (index < pokemons.Count)
                {
                    current.PreviousMatch1 = new Match(pokemons[index++]);
                    current.PreviousMatch1.NextMatch = current;
                    queue.Enqueue(current.PreviousMatch1);
                }

                // Assign right child
                if (index < pokemons.Count)
                {
                    current.PreviousMatch2 = new Match(pokemons[index++]);
                    current.PreviousMatch2.NextMatch = current;
                    queue.Enqueue(current.PreviousMatch2);
                }
            }

            return root;
        }
        

        public Match FindMatchById(int matchId)
        {
            // TODO
            return null;
        }
    }
}