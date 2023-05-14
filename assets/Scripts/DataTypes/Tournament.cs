using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTypes
{
    public class Tournament
    {
        public Match FinalMatch { get; private set; }

        private readonly Dictionary<int, Match> _matchByIdMap;

        public Tournament(IList<(string playerName, string pokemonName)> playerPokemonPairs)
        {
            _matchByIdMap = new Dictionary<int, Match>();
            InitTournament(playerPokemonPairs);
        }

        private void InitTournament(IList<(string playerName, string pokemonName)> playerPokemonPairs)
        {
            // Shuffle the player-pokemon pairs to randomize the seeding
            playerPokemonPairs.Shuffle();
            
            // Create a queue to hold the shuffled Pokemon
            Queue<Pokemon> pokemonQueue = new Queue<Pokemon>();
   
            // Enqueue the Pokemon in the shuffled order
            foreach (var newPokemon in playerPokemonPairs.Select(choice => new Pokemon(choice.Item1, choice.Item2)))
            {
                pokemonQueue.Enqueue(newPokemon);
            }
            
            // Generate a tournament tree and return its root.
            FinalMatch = CreateRoundMatches(pokemonQueue);
        }

        private Match CreateRoundMatches(Queue<Pokemon> pokemonQueue)
        {
            Queue<Match> matchesQueue = new Queue<Match>();
            int matchId = 1;
            int round = 1;
            
            // Pair participants into first round matches
            while (pokemonQueue.Count != 0)
            {
                Pokemon p1 = pokemonQueue.Dequeue();
                Pokemon p2 = pokemonQueue.Dequeue();
                Match match = new Match(p1, p2, round, matchId, true);
                _matchByIdMap.Add(matchId, match);
                matchId++;
                matchesQueue.Enqueue(match);
            }

            round++;
            
            // Pair matches of equal levels up until the final match is created
            while (matchesQueue.Count > 1)
            {
                Match m1 = matchesQueue.Dequeue();
                Match m2 = matchesQueue.Dequeue();
                if (round == m1.Round || round == m2.Round)
                {
                    round++;
                }
                
                Match nextMatch = new Match(round, matchId, false);
                _matchByIdMap.Add(matchId, nextMatch);
                matchId++;
                m1.NextMatch = nextMatch;
                m2.NextMatch = nextMatch;
                nextMatch.PreviousMatch1 = m1;
                nextMatch.PreviousMatch2 = m2;
                matchesQueue.Enqueue(nextMatch);
            }

            return matchesQueue.Dequeue();
        }
        
        public Match FindMatchById(int matchId)
        {
            return _matchByIdMap[matchId];
        }
    }
}