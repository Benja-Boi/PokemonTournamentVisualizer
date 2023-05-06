using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTypes;

public class OverviewScreenController : MonoBehaviour
{
    public Tournament Tournament;
    public GameObject roundUIElementPrefab;
    public GameObject matchUIElementPrefab;
    public GameObject pokemonUIElementPrefab;
    public Transform roundsContainer;
    
    private Dictionary<int, GameObject> roundUIElements;

    private void Start()
    {
        roundUIElements = new Dictionary<int, GameObject>();
        GenerateTournamentUI();
    }

    private void GenerateTournamentUI()
    {
        // Clear existing UI elements
        foreach (Transform child in roundsContainer)
        {
            Destroy(child.gameObject);
        }
        roundUIElements.Clear();

        // Generate UI elements for each match in the tournament
        TraverseAndGenerateUI(tournament.root);
    }

}
