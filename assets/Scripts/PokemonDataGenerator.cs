using System.IO;
using ScriptableObjects;
using ScriptableObjects.DataTypes;
using UnityEditor;
using UnityEngine;

public class PokemonDataGenerator
{
    // Set the paths for the CSV file and the sprites folder
    private const string CsvFilePath = "Assets/Resources/Pokedex_Map_mock.csv";
    private const string SpritesFolderPath = "Assets/Sprites";
    private const string OutputFolderPath = "Assets/ScriptableObjects/PokemonData";
    private const string DefaultSpritePath = "Assets/0.png";
    
    private const string DBOutputName = "PokemonDatabase";
    private const string DBOutputFolderPath = "Assets/Resources/ScriptableObjects/PokemonDB";

    [MenuItem("Tools/Generate Pokemon Data Assets")]
    public static void GeneratePokemonData()
    {
        // The database object to hold all the instances for easy access
        //pokemonDatabase.Clear();

        // Load the default sprite
        Sprite defaultSprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultSpritePath);

        // Read the CSV file line by line
        using (StreamReader reader = new StreamReader(CsvFilePath))
        {
            while (reader.ReadLine() is { } line)
            {
                // Split the line into Pokedex number and Pokemon name
                string[] values = line.Split(',');
                int pokedexNumber = int.Parse(values[0]);
                string pokemonName = values[1];
                
                // Load the sprite, or use the default sprite if loading fails
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{SpritesFolderPath}/{pokedexNumber}.png") ?? defaultSprite;

                // Create a new PokemonData ScriptableObject
                PokemonData pokemonData = ScriptableObject.CreateInstance<PokemonData>();
                pokemonData.pokemonName = pokemonName;
                pokemonData.sprite = sprite;
                pokemonData.id = pokedexNumber;

                // Save the PokemonData instance as an asset in the project
                AssetDatabase.CreateAsset(pokemonData, $"{OutputFolderPath}/{pokedexNumber}_{pokemonName}.asset");
            }
        }

        // Refresh the AssetDatabase to show the new instances in the Unity Editor
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    
    [MenuItem("Tools/Generate Pokemon Database")]
    public static void GeneratePokemonDatabase()
    {
        // The database object to hold all the instances for easy access
        PokemonDatabase pokemonDB = ScriptableObject.CreateInstance<PokemonDatabase>();

        // Load the default sprite
        Sprite defaultSprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultSpritePath);

        // Read the CSV file line by line
        using (StreamReader reader = new StreamReader(CsvFilePath))
        {
            while (reader.ReadLine() is { } line)
            {
                // Split the line into Pokedex number and Pokemon name
                string[] values = line.Split(',');
                int pokedexNumber = int.Parse(values[0]);
                string pokemonName = values[1];
                
                // Load the sprite, or use the default sprite if loading fails
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{SpritesFolderPath}/{pokedexNumber}.png") ?? defaultSprite;

                // Create a new PokemonData ScriptableObject
                PokemonData pokemonData = ScriptableObject.CreateInstance<PokemonData>();
                pokemonData.pokemonName = pokemonName;
                pokemonData.sprite = sprite;
                pokemonData.id = pokedexNumber;
                
                // Save the PokemonData instance as an asset in the project
                AssetDatabase.CreateAsset(pokemonData, $"{OutputFolderPath}/{pokemonName}.asset");

                // Add the pokemon data to the database
                pokemonDB.Add(pokemonData);
            }
        }

        // Save the PokemonData instance as an asset in the project
        AssetDatabase.CreateAsset(pokemonDB, $"{DBOutputFolderPath}/{DBOutputName}.asset");
        
        // Refresh the AssetDatabase to show the new instances in the Unity Editor
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}