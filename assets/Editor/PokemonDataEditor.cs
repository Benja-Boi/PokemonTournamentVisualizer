using ScriptableObjects;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PokemonData))]
public class PokemonDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Get the target PokemonData instance
        PokemonData pokemonData = (PokemonData)target;

        // Display the sprite in the Inspector
        if (pokemonData.sprite != null)
        {
            Rect spriteRect = GUILayoutUtility.GetRect(100, 100);
            EditorGUI.DrawPreviewTexture(spriteRect, pokemonData.sprite.texture);
        }
    }
}

