using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject overViewScreen;
    public GameObject battleScreen;
    private TournamentManager _tournamentManager;

    private void Awake()
    {
        _tournamentManager = FindObjectOfType<TournamentManager>();
    }

    private void Start()
    {
        startScreen.SetActive(true);
        overViewScreen.SetActive(false);
        battleScreen.SetActive(false);
    }

    public void StartTournament()
    {
        startScreen.SetActive(false);
        overViewScreen.SetActive(true);
        battleScreen.SetActive(false);
        
        _tournamentManager.StartTournament();
    }
}
