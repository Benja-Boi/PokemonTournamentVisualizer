using System.IO;
using ScriptableObjects;
using ScriptableObjects.DataTypes;
using UnityEditor;
using UnityEngine;

public static class PokemonDataGenerator
{
    // Set the paths for the CSV file and the sprites folder
    private const string CsvFilePathDemo = "Assets/Resources/Pokedex_Map_mock.csv";
    private const string CsvFilePathFull = "Assets/Resources/Pokedex_Map.csv";
    private const string SpritesFolderPath = "Assets/Sprites";
    private const string OutputFolderPath = "Assets/ScriptableObjects/PokemonData";
    private const string DefaultSpritePath = "Assets/0.png";
    
    private const string DBOutputName = "PokemonDatabase";
    private const string DBOutputFolderPath = "Assets/ScriptableObjects/PokemonDB";

    [MenuItem("Tools/Generate Pokemon Demo Data Assets")]
    public static void GeneratePokemonDemoData()
    {
        GeneratePokemonData(CsvFilePathDemo);
    }
    
    [MenuItem("Tools/Generate Pokemon Full Data Assets")]
    public static void GeneratePokemonFullData()
    {
        GeneratePokemonData(CsvFilePathFull);
    }

    private static void GeneratePokemonData(string csvPath)
    {

        // Load the default sprite
        Sprite defaultSprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultSpritePath);

        // Read the CSV file line by line
        using (StreamReader reader = new StreamReader(csvPath))
        {
            while (reader.ReadLine() is { } line)
            {
                // Split the line into Pokedex number and Pokemon name
                string[] values = line.Split(',');
                int pokedexNumber = int.Parse(values[0]);
                string pokemonName = values[1];
                
                // Load the sprite, or use the default sprite if loading fails
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{SpritesFolderPath}/back/{pokedexNumber}.png") ?? defaultSprite;
                Sprite backSprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{SpritesFolderPath}/back/{pokedexNumber}.png") ?? defaultSprite;

                // Create a new PokemonData ScriptableObject
                PokemonData pokemonData = ScriptableObject.CreateInstance<PokemonData>();
                pokemonData.pokemonName = pokemonName;
                pokemonData.sprite = sprite;
                pokemonData.backSprite = backSprite;
                pokemonData.id = pokedexNumber;

                // Save the PokemonData instance as an asset in the project
                AssetDatabase.CreateAsset(pokemonData, $"{OutputFolderPath}/{pokedexNumber}_{pokemonName}.asset");
            }
        }

        // Refresh the AssetDatabase to show the new instances in the Unity Editor
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        
        Debug.Log("Data Load complete successfully!");
    }
    
    [MenuItem("Tools/Generate Pokemon Demo Database")]
    public static void GeneratePokemonDemoDatabase()
    {
        GeneratePokemonDatabase(CsvFilePathDemo);
    }
    
    [MenuItem("Tools/Generate Pokemon Full Database")]
    public static void GeneratePokemonFullDatabase()
    {
        GeneratePokemonDatabase(CsvFilePathFull);
    }

    private static void GeneratePokemonDatabase(string csvPath)
    {
        // The database object to hold all the instances for easy access
        PokemonDatabase pokemonDB = ScriptableObject.CreateInstance<PokemonDatabase>();

        // Load the default sprite
        Sprite defaultSprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultSpritePath);

        // Read the CSV file line by line
        using (StreamReader reader = new StreamReader(csvPath))
        {
            while (reader.ReadLine() is { } line)
            {
                // Split the line into Pokedex number and Pokemon name
                string[] values = line.Split(',');
                int pokedexNumber = int.Parse(values[0]);
                string pokemonName = values[1];
                
                // Load the sprite, or use the default sprite if loading fails
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{SpritesFolderPath}/{pokedexNumber}.png") ?? defaultSprite;
                Sprite backSprite = AssetDatabase.LoadAssetAtPath<Sprite>($"{SpritesFolderPath}/back/{pokedexNumber}.png") ?? defaultSprite;

                // Create a new PokemonData ScriptableObject
                PokemonData pokemonData = ScriptableObject.CreateInstance<PokemonData>();
                pokemonData.pokemonName = pokemonName ?? "";
                pokemonData.sprite = sprite;
                pokemonData.backSprite = backSprite;
                pokemonData.id = pokedexNumber;

                // Save the PokemonData instance as an asset in the project
                AssetDatabase.CreateAsset(pokemonData, $"{OutputFolderPath}/{pokemonName}.asset");

                // Add the pokemon data to the database
                pokemonDB.Add(pokemonData);
            }
        }

        // Save the PokemonData instance as an asset in the project
        AssetDatabase.CreateAsset(pokemonDB, $"{DBOutputFolderPath}/{DBOutputName}_{pokemonDB.AllPokemon.Count}.asset");
        
        // Refresh the AssetDatabase to show the new instances in the Unity Editor
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}