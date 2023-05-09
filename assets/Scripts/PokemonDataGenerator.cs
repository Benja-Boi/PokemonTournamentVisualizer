using System.IO;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

public class PokemonDataGenerator
{
    [MenuItem("Tools/Generate Pokemon Data")]
    public static void GeneratePokemonData()
    {
        // Set the paths for the CSV file and the sprites folder
        string csvFilePath = "Assets/Resources/Pokedex_Map.csv";
        string spritesFolderPath = "Assets/Sprites";
        string outputFolderPath = "Assets/ScriptableObjects/PokemonData";
        string defaultSpritePath = "Assets/0.png";

        // Load the default sprite
        Sprite defaultSprite = AssetDatabase.LoadAssetAtPath<Sprite>(defaultSpritePath);

        // Read the CSV file line by line
        using (StreamReader reader = new StreamReader(csvFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Split the line into Pokedex number and Pokemon name
                string[] values = line.Split(',');
                int pokedexNumber = int.Parse(values[0]);
                string pokemonName = values[1];

                // Load the sprite
                // Load the sprite, or use the default sprite if loading fails
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{spritesFolderPath}/{pokedexNumber}.png") ?? defaultSprite;

                // Create a new PokemonData ScriptableObject
                PokemonData pokemonData = ScriptableObject.CreateInstance<PokemonData>();
                pokemonData.pokemonName = pokedexNumber + "_" + pokemonName;
                pokemonData.sprite = sprite;
                pokemonData.id = pokedexNumber;

                // Save the PokemonData instance as an asset in the project
                AssetDatabase.CreateAsset(pokemonData, $"{outputFolderPath}/{pokemonName}.asset");
            }
        }

        // Refresh the AssetDatabase to show the new instances in the Unity Editor
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}