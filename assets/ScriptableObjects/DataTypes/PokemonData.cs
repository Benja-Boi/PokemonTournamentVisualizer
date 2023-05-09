using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PokemonData", menuName = "ScriptableObjects/PokemonData", order = 1)]

    public class PokemonData : ScriptableObject
    {
        public string pokemonName;
        public Sprite sprite;
        public int id;
    }
}
