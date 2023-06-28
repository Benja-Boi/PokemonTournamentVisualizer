using System;
using System.Collections.Generic;
using Game_Events;
using Mono.CompilerServices.SymbolWriter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup activeScreen;
    public CanvasGroup startScreen;
    public CanvasGroup overViewScreen;
    public GameEvent startTournamentEvent;
    public CanvasGroup battleScreen;
    private TournamentManager _tournamentManager;
    private List<CanvasGroup> _screens;
        
    private void Awake()
    {
        _tournamentManager = FindObjectOfType<TournamentManager>();
        _screens = new List<CanvasGroup>();
    }
    
    private void Start()
    {
        _screens.Add(startScreen);
        _screens.Add(overViewScreen);
        _screens.Add(battleScreen);
        HideAllScreens();
        ActivateScreen(startScreen);
    }

    private void ActivateScreen(CanvasGroup newActiveScreen)
    {
        if (newActiveScreen == activeScreen) return;
        if (activeScreen != null)
        {
            activeScreen.alpha = 0;
            activeScreen.transform.position = Vector3.zero;
        }
        newActiveScreen.alpha = 1;
        newActiveScreen.transform.position = 0.5f * Vector3.back;
        activeScreen = newActiveScreen;
    }

    private void HideAllScreens()
    {
        foreach (var screen in _screens)
        {
            screen.alpha = 0;
            screen.transform.position = Vector3.zero;
        }
    }

    public void StartTournament()
    {
        ActivateScreen(overViewScreen);
        _tournamentManager.StartTournament();
        startTournamentEvent.Raise();
    }

    public void ChangeScreens()
    {
        if (activeScreen == battleScreen)
        {
            ActivateScreen(overViewScreen);
        }
        else
        {
            if (activeScreen == overViewScreen)
            {
                ActivateScreen(battleScreen);
            }            
        }

    }
}
