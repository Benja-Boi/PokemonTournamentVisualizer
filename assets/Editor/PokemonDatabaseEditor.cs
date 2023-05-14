using ScriptableObjects.DataTypes;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(PokemonDatabase))]
    public class PokemonDatabaseEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
        }
    }
}

