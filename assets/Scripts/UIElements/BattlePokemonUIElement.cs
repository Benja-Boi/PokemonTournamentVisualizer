using DataTypes;
using UnityEngine.UI;

namespace UIElements
{
    public class BattlePokemonUIElement : PokemonUIElement
    {
        public Text winButtonText;

        public new void SetPokemon(Pokemon newPokemon)
        {
            if (newPokemon == null) return;
            base.SetPokemon(newPokemon);
            SetButtonText(newPokemon.PlayerName, newPokemon.Name);
        }
    
        private void SetButtonText(string pokemonPlayerName, string pokemonName)
        {
            winButtonText.text = pokemonPlayerName + "'s " + pokemonName + " wins!";
        }
    }
}
