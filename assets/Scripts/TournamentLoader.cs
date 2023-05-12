using System.Collections.Generic;
using System.IO;
public static class TournamentLoader
{
    private const string DefaultPath = "Assets/Resources/Tournament_Data.csv";

    public static List<(string playerName, string pokemonName)> LoadTournament(string path = DefaultPath)
    {
        var tournamentData = new List<(string playerName, string pokemonName)>();

        // Read the CSV file line by line
        using StreamReader reader = new StreamReader(path);
        while (reader.ReadLine() is { } line)
        {
            // Split the line into Player name and Pokemon name
            string[] values = line.Split(',');
            string playerName = values[0];
            string pokemonName = values[1];
                    
            tournamentData.Add((playerName, pokemonName));
        }

        return tournamentData;
    }
}