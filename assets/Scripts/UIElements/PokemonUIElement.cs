using DataTypes;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
    public class PokemonUIElement : MonoBehaviour
    {
        public Pokemon Pokemon { get; private set; }
        public Image sprite;
        public void SetPokemon(Pokemon newPokemon)
        {
            Pokemon = newPokemon;
            sprite.sprite = Pokemon.Sprite;
            sprite.color = Color.white;
        }
    }
}