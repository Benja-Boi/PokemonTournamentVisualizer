using DataTypes;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
    public class WinnerPokemonUIElement : PokemonUIElement
    {
        public Text winButtonText;

        public new void SetPokemon(Pokemon newPokemon)
        {
            if (newPokemon == null) return;
            base.SetPokemon(newPokemon);
            SetButtonText(newPokemon.PlayerName, newPokemon.Name);
            sprite.color = Color.white;
            sprite.transform.localScale = new Vector3(1, 1, 1);
        }
   
        private void SetButtonText(string pokemonPlayerName, string pokemonName)
        {
            winButtonText.text = pokemonPlayerName + "'s " + pokemonName + " IS THE GRAND WINNER!";
        }
    }
}