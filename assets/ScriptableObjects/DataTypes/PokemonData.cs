using UnityEngine;

namespace ScriptableObjects.DataTypes
{
    [CreateAssetMenu(fileName = "PokemonData", menuName = "Pokemon/PokemonData", order = 1)]

    public class PokemonData : ScriptableObject
    {
        public string pokemonName;
        public Sprite sprite;
        public Sprite backSprite;
        public int id;
    }
}
