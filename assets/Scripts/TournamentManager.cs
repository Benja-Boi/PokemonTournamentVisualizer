using System;
using System.Collections.Generic;
using DataTypes;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    public PokemonDataManager pokemonDataManager;
    private Tournament _tournament;
    public OverviewScreenController overviewScreenController;
    public bool populateRandomly;
    public int numberOfRounds = 3;
    public int playerCount;
    
    private void Awake()
    {
        if (pokemonDataManager == null)
        {
            pokemonDataManager = FindObjectOfType<PokemonDataManager>();
        }

        if (overviewScreenController)
        {
            overviewScreenController = FindObjectOfType<OverviewScreenController>();
        }
    }

    void Start()
    {
        var participants = populateRandomly ? GenerateRandomParticipants((int)Math.Pow(2, numberOfRounds)) : TournamentLoader.LoadTournament();
        playerCount = participants.Count;
        _tournament = new Tournament(participants, numberOfRounds);
    }

    public void StartTournament()
    {
        overviewScreenController.GenerateTournamentUI(_tournament);
    }

    private List<(string playerName, string pokemonName)> GenerateRandomParticipants(int numOfParticipants)
    {
        List<(string playerName, string pokemonName)> participants = new List<(string playerName, string pokemonName)>();
        for (int i = 0; i < numOfParticipants; i++)
        {
            string playerName = MyUtils.RandomString(5);
            string pokemonName = pokemonDataManager.GetRandomPokemonName();
            participants.Add((playerName, pokemonName));
        }

        return participants;
    }
    
    public Match FindMatchById(int matchId)
    {
        return _tournament.FindMatchById(matchId);
    }
}
