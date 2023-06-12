using DataTypes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MatchUIElement : MonoBehaviour
{
    public MatchState state;
    public Match Match;
    public int id; 
    public PokemonUIElement pokemon1;
    public PokemonUIElement pokemon2;
    public PokemonUIElement winner;
    public MatchUIElement previousMatch1;
    public MatchUIElement previousMatch2;
    public MatchUIElement nextMatch;
    public Image background;
    
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
        state = newState;
        switch (newState)
        {
            case MatchState.Available:
                background.color = Color.white;
                break;
            case MatchState.Completed:
                background.color = Color.gray;
                break;
            case MatchState.Unavailable:
                background.color = Color.black;
                break;
        }
        
    }

    public void SetWinner(Pokemon matchWinner)
    {
        winner.SetPokemon(matchWinner);
    }
}