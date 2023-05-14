using DataTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonUIElement : MonoBehaviour
{
    
    public Pokemon Pokemon;
    public Image sprite;
    public TextMeshProUGUI playerName;

    public void SetPokemon(Pokemon newPokemon)
    {
        if (newPokemon == null) return;
        Pokemon = newPokemon;
        sprite.sprite = Pokemon.Sprite;
        playerName.text = Pokemon.PlayerName;
    }

}