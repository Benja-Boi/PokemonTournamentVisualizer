using DataTypes;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
    public class MatchUIElement : MonoBehaviour
    {
        public MatchState state;
        public Match Match;
        public int id; 
        public BracketPokemonUIElement pokemon1;
        public BracketPokemonUIElement pokemon2;
        public BracketPokemonUIElement winner;
        public MatchUIElement previousMatch1;
        public MatchUIElement previousMatch2;
        public MatchUIElement nextMatch;
        public Image background;
        public Image midground;
    
        public Color availableBackgroundColor;
        public Color availableMidgroundColor;
        public Color unavailableBackgroundColor;
        public Color unavailableMidgroundColor;
        public Color completedBackgroundColor;
        public Color completedMidgroundColor;
    
        public void SetMatch(Match match)
        {
            Match = match;
            id = match.ID;
            pokemon1.SetPokemon(match.Pokemon1);
            pokemon2.SetPokemon(match.Pokemon2);
            winner.SetPokemon(match.Winner);
        }

        public void SetState(MatchState newState)
        {
            Debug.Log("Setting state of match " + id + " to " + newState + ".");
            if (state == newState) return;
            state = newState;
            switch (newState)
            {
                case MatchState.Available:
                    background.color = availableBackgroundColor;
                    midground.color = availableMidgroundColor;
                    break;
                case MatchState.Completed:
                    background.color = completedBackgroundColor;
                    midground.color = completedMidgroundColor;
                    break;
                case MatchState.Unavailable:
                    background.color = unavailableBackgroundColor;
                    midground.color = unavailableMidgroundColor;
                    break;
            }
        
        }

        public void SetWinner(Pokemon matchWinner)
        {
            winner.SetPokemon(matchWinner);
            bool isPlayer1Won = matchWinner == pokemon1.Pokemon;
            pokemon1.PokemonDidWinMatch(isPlayer1Won);
            pokemon2.PokemonDidWinMatch(!isPlayer1Won);
        }
    }
}