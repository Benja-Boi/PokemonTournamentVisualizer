using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTypes;
using UnityEngine.UI;

public class OverviewScreenController : MonoBehaviour
{
    public Transform tournamentContainer;
    public GameObject roundUIElementPrefab;
    public GameObject matchUIElementPrefab;
    public Transform initialRoundTransform;

    public Vector3 roundHorizontalOffset = new Vector3(5f, 0, 0);
    public Vector3 matchVerticalOffset = new Vector3(0, 5f, 0);
    
    private Tournament _tournament;
    private Dictionary<int, GameObject> _roundUIElements;

    private void Start()
    {
        _roundUIElements = new Dictionary<int, GameObject>();
    }

    public void GenerateTournamentUI(Tournament newTournament)
    {
        _tournament = newTournament;
        
        // Clear existing UI elements
        foreach (Transform child in initialRoundTransform)
        {
            Destroy(child.gameObject);
        }
        _roundUIElements.Clear();

        // Generate UI elements for each match in the tournament
        TraverseAndGenerateUI(_tournament.FinalMatch);
    }

    private void TraverseAndGenerateUI(Match match)
    {
        if (match == null) return;

        // Instantiate a new RoundUIElement for the current round, if needed
        GameObject roundUIElement = GetOrCreateRoundUIElement(match.Round);

        // Instantiate a new MatchUIElement and set up its properties
        GameObject matchUIObject = Instantiate(matchUIElementPrefab, roundUIElement.transform);
        MatchUIElement matchUIElement = matchUIObject.GetComponent<MatchUIElement>();
        matchUIElement.SetMatch(match);

        // Set up the UI Button click listener
        Button matchButton = matchUIObject.GetComponent<Button>();
        matchButton.onClick.AddListener(() => OnMatchButtonClick(matchUIElement.Match.ID));

        // Update the match UI state based on the current match state
        UpdateMatchUI(matchUIElement, match);

        // Traverse child nodes
        TraverseAndGenerateUI(match.PreviousMatch1);
        TraverseAndGenerateUI(match.PreviousMatch2);
    }

    private GameObject GetOrCreateRoundUIElement(int roundNumber)
    {
        if (_roundUIElements.ContainsKey(roundNumber)) return _roundUIElements[roundNumber];

        Vector3 newRoundTransform = initialRoundTransform.position + (roundNumber - 1) * roundHorizontalOffset;
        GameObject roundUIElement = Instantiate(roundUIElementPrefab, newRoundTransform, tournamentContainer.rotation, tournamentContainer);
        _roundUIElements[roundNumber] = roundUIElement;
        roundUIElement.name = "Round_" + roundNumber;

        return _roundUIElements[roundNumber];
    }

    public void OnMatchButtonClick(int matchId)
    {
        Match clickedMatch = _tournament.FindMatchById(matchId);

        if (clickedMatch != null && clickedMatch.IsAvailable)
        {
            // Simulate the match and update the winner
            clickedMatch.SimulateMatch();

            // Update the UI for this match and the next match, if available
            UpdateMatchUIForMatchId(matchId);
            UpdateMatchUIForMatchId(clickedMatch.NextMatchId());
        }
    }

    private void UpdateMatchUIForMatchId(int matchId)
    {
        throw new System.NotImplementedException();
    }

    private void UpdateMatchUI(MatchUIElement matchUIElement, Match match)
    {
        if (match.IsAvailable)
        {
            matchUIElement.SetState(MatchState.Available);
        }
        else if (match.IsComplete)
        {
            matchUIElement.SetState(MatchState.Completed);
            matchUIElement.SetWinner(match.Winner);
        }
        else
        {
            matchUIElement.SetState(MatchState.Unavailable);
        }
    }
}
