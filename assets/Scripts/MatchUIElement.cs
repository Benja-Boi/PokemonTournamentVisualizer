using DataTypes;
using UnityEngine;

public class MatchUIElement : MonoBehaviour
{
    public MatchState state;
    public Match Match;
    public PokemonUIElement pokemon1;
    public PokemonUIElement pokemon2;
    public PokemonUIElement winner;

    public void SetMatch(Match match)
    {
        Match = match;
        pokemon1.SetPokemon(match.Pokemon1);
        pokemon2.SetPokemon(match.Pokemon2);
        winner.SetPokemon(match.Winner);
    }
    
    
    public void SetState(MatchState available)
    {
        state = available;
    }

    public void SetWinner(Pokemon matchWinner)
    {
        winner.SetPokemon(matchWinner);
    }
}