using System.Collections;
using System.Collections.Generic;
using DataTypes;
using TMPro;
using UIElements;
using UnityEngine;
using UnityEngine.UI;

public class BracketPokemonUIElement : PokemonUIElement
{
    public Image background;
    public TextMeshProUGUI playerName;
    public Color pendingBackgroundColor;
    public Color winnerBackgroundColor;
    public Color loserBackgroundColor;
    
    public new void SetPokemon(Pokemon newPokemon)
    {
        if (newPokemon == null) return;
        base.SetPokemon(newPokemon);
        playerName.text = Pokemon.PlayerName;
        playerName.color = Color.white;
    }
    
    public void PokemonDidWinMatch(bool isWinner)
    {
        background.color = isWinner ? winnerBackgroundColor : loserBackgroundColor;
    }
}
