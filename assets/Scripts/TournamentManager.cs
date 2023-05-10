using System.Collections;
using System.Collections.Generic;
using DataTypes;
using DefaultNamespace;
using UnityEngine;

public class TournamentManager : MonoBehaviour
{
    public Tournament Tournament;
    public OverviewScreenController OverviewScreenController;
    
    void Start()
    {
        Tournament = new Tournament(TournamentLoader.LoadTournament());
        OverviewScreenController.GenerateTournamentUI(Tournament);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
