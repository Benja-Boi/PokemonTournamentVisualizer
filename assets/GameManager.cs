using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup startScreen;
    public CanvasGroup overViewScreen;
    public CanvasGroup battleScreen;
    private TournamentManager _tournamentManager;

    private void Awake()
    {
        _tournamentManager = FindObjectOfType<TournamentManager>();
    }

    private void Start()
    {
        startScreen.alpha = 1;
        overViewScreen.alpha = 0;
        battleScreen.alpha = 0;
    }

    public void StartTournament()
    {
        startScreen.alpha = 0;
        overViewScreen.alpha = 1;
        battleScreen.alpha = 0;
        
        _tournamentManager.StartTournament();
    }

    public void ChangeScreens()
    {
        if (Math.Abs(battleScreen.alpha - 1) < .01)
        {
            ShowOverviewScreen();
        }
        else
        {
            ShowBattleScreen();
        }
    }
    
    public void ShowBattleScreen()
    {
        startScreen.alpha = 0;
        overViewScreen.alpha = 0;
        battleScreen.alpha = 1;
    }
    
    public void ShowOverviewScreen()
    {
        startScreen.alpha = 0;
        overViewScreen.alpha = 1;
        battleScreen.alpha = 0;
    }
}
