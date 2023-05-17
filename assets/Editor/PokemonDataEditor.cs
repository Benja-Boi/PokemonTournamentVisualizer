using ScriptableObjects;
using ScriptableObjects.DataTypes;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PokemonData))]
public class PokemonDataEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Get the target PokemonData instance
        PokemonData pokemonData = (PokemonData)target;

        // Display the sprite in the Inspector
        if (pokemonData.sprite == null) return;
        
        float aspectRatio = (float)pokemonData.sprite.texture.width / (float)pokemonData.sprite.texture.height;
        float previewSize = 100;

        // Calculate the width and height of the rect based on the aspect ratio
        float width = aspectRatio >= 1 ? previewSize : previewSize * aspectRatio;
        float height = aspectRatio >= 1 ? previewSize / aspectRatio : previewSize;
        Rect spriteRect = GUILayoutUtility.GetRect(width, height);
            
        // Draw the sprite texture using the calculated rect
        EditorGUI.DrawTextureTransparent(spriteRect, pokemonData.sprite.texture, ScaleMode.ScaleToFit);
        
        // Display the sprite in the Inspector
        if (pokemonData.backSprite == null) return;
        
        float backAspectRatio = (float)pokemonData.backSprite.texture.width / (float)pokemonData.backSprite.texture.height;
        float backPreviewSize = 100;

        // Calculate the width and height of the rect based on the aspect ratio
        float backWidth = backAspectRatio >= 1 ? backPreviewSize : backPreviewSize * backAspectRatio;
        float backHeight = backAspectRatio >= 1 ? backPreviewSize / backAspectRatio : backPreviewSize;
        Rect backSpriteRect = GUILayoutUtility.GetRect(backWidth, backHeight);
            
        // Draw the sprite texture using the calculated rect
        EditorGUI.DrawTextureTransparent(backSpriteRect, pokemonData.backSprite.texture, ScaleMode.ScaleToFit);
    }
}

