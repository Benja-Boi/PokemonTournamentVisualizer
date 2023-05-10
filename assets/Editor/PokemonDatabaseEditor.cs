using ScriptableObjects.DataTypes;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(PokemonDatabase))]
    public class PokemonDatabaseEditor : UnityEditor.Editor
    {
        private SerializedProperty _allPokemon;
    
        private void OnEnable()
        {
            _allPokemon = serializedObject.FindProperty("_allPokemon");
        }
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_allPokemon, new GUIContent("All Pokemon"), true);

            EditorGUILayout.Space();
        
            // for (int i = 0; i < allPokemon.arraySize; i++)
            // {
            //     SerializedProperty pokemonData = allPokemon.GetArrayElementAtIndex(i);
            //     SerializedProperty pokemonName = pokemonData.FindPropertyRelative("pokemonName");
            //     SerializedProperty pokemonSprite = pokemonData.FindPropertyRelative("sprite");
            //     SerializedProperty pokemonId = pokemonData.FindPropertyRelative("id");
            //     
            //     EditorGUILayout.BeginHorizontal();
            //     EditorGUILayout.LabelField(pokemonName.stringValue, GUILayout.Width(150));
            //     EditorGUILayout.IntField(pokemonId.intValue, GUILayout.Width(50));
            //     EditorGUILayout.ObjectField(pokemonSprite.objectReferenceValue, typeof(Sprite), false);
            //     EditorGUILayout.EndHorizontal();
            // }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

