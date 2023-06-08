using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DataTypes;
using Game_Events;
using Unity.Mathematics;
using UnityEngine.UI;

public class OverviewScreenController : MonoBehaviour
{
    public Transform tournamentContainer;
    public GameObject roundUIElementPrefab;
    public GameObject matchUIElementPrefab;
    public Transform initialRoundTransform;
    public GameEvent matchStarted;
    
    public Vector3 roundHorizontalOffset;
    public Vector3 matchVerticalOffset;
    public float matchSizeModifier;
    public float roundSpaceModifier;

    private int _activeMatchId;
    private int _matchCount;
    private Tournament _tournament;
    private Dictionary<int, GameObject> _roundUIElements;
    private Dictionary<int, List<MatchUIElement>> _matches;
    private Dictionary<int, MatchUIElement> _matchByIdMap;

    public void Awake()
    {
        _matches = new Dictionary<int, List<MatchUIElement>>();
        _matchByIdMap = new Dictionary<int, MatchUIElement>();
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
        TraverseAndGenerateUI(_tournament.FinalMatch, null);
        SpaceMatches();
    }

    private void SpaceMatches()
    {
        int numRounds = _matches.Aggregate((l, r) => l.Key > r.Key ? l : r).Key;
        SpaceFirstRoundMatches(numRounds);

        for (int round = 2; round <= numRounds; round++)
        {
            var roundMatches = _matches[round];
            
            if (round == 1) continue;
            float roundXVal = _roundUIElements[round].transform.position.x;

            foreach (var match in roundMatches)
            {
                float matchYVal = (match.previousMatch1.transform.position.y + match.previousMatch2.transform.position.y) / 2;
                match.transform.position = new Vector3(roundXVal, matchYVal, 0);
            }
        }
    }

    private void SpaceFirstRoundMatches(int numRounds)
    {
        int matchesInFirstRound = (int) math.pow(2, numRounds - 1);
        Vector3 topPosition = _roundUIElements[1].transform.position + matchesInFirstRound * matchVerticalOffset / 2;
        var firstRoundMatches = _matches[1];
        for (int j = 0; j < matchesInFirstRound; j++)
        {
            Vector3 newPosition = topPosition - j * matchVerticalOffset;
            firstRoundMatches[j].transform.position = newPosition;
        }
    }

    private MatchUIElement TraverseAndGenerateUI(Match match, MatchUIElement nextMatchUIElement)
    {
        if (match == null) return null;

        // Instantiate a new RoundUIElement for the current round, if needed
        GameObject roundUIElement = GetOrCreateRoundUIElement(match.Round);

        // Instantiate a new MatchUIElement and set up its properties
        GameObject matchUIObject = Instantiate(matchUIElementPrefab, roundUIElement.transform);
        matchUIObject.transform.localScale *= (1 + (match.Round - 1) * matchSizeModifier);
        MatchUIElement matchUIElement = matchUIObject.GetComponent<MatchUIElement>();
        matchUIElement.nextMatch = nextMatchUIElement;
        matchUIElement.SetMatch(match);
        matchUIElement.SetState(match.Round == 1 ? MatchState.Available : MatchState.Unavailable);
        _matchByIdMap.Add(match.ID, matchUIElement);
        if (_matches.ContainsKey(match.Round))
        {
            _matches[match.Round].Add(matchUIElement);
        }
        else
        {
            _matches.Add(match.Round, new List<MatchUIElement>());
            _matches[match.Round].Add(matchUIElement);
        }

        // Set up the UI Button click listener
        Button matchButton = matchUIObject.GetComponent<Button>();
        matchButton.onClick.AddListener(() => OnMatchButtonClick(matchUIElement.Match.ID));

        // Update the match UI state based on the current match state
        UpdateMatchUI(matchUIElement, match);

        // Traverse child nodes
        matchUIElement.previousMatch1 = TraverseAndGenerateUI(match.PreviousMatch1, matchUIElement);
        matchUIElement.previousMatch2 = TraverseAndGenerateUI(match.PreviousMatch2, matchUIElement);

        return matchUIElement;
    }

    private GameObject GetOrCreateRoundUIElement(int roundNumber)
    {
        if (_roundUIElements.ContainsKey(roundNumber)) return _roundUIElements[roundNumber];

        Vector3 newRoundTransform = initialRoundTransform.position + math.pow((roundNumber - 1), roundSpaceModifier) * roundHorizontalOffset;
        GameObject roundUIElement = Instantiate(roundUIElementPrefab, newRoundTransform, tournamentContainer.rotation, tournamentContainer);
        _roundUIElements[roundNumber] = roundUIElement;
        roundUIElement.name = "Round_" + roundNumber;

        return _roundUIElements[roundNumber];
    }

    private void OnMatchButtonClick(int matchId)
    {
        Debug.Log("Match Clicked: " + matchId);
        Match clickedMatch = _tournament.FindMatchById(matchId);

        if (clickedMatch is { IsAvailable: true })
        {
            _activeMatchId = matchId;
            matchStarted.Raise(matchId);
        }
    }

    public void OnMatchComplete(bool isPlayer1Won)
    {
        
        Debug.Log("Match " + _activeMatchId + " is complete.");
        Match clickedMatch = _tournament.FindMatchById(_activeMatchId);
        clickedMatch.SetWinner(isPlayer1Won);
        
        MatchUIElement matchUI = _matchByIdMap[_activeMatchId];
        matchUI.SetState(MatchState.Completed);

        // Update the UI for this match and the next match, if available
        UpdateMatchUIForMatchId(_activeMatchId);
        UpdateMatchUIForMatchId(clickedMatch.NextMatchId());
    }

    private void UpdateMatchUIForMatchId(int matchId)
    {
        Debug.Log("Updating UI for match " + _activeMatchId + ".");
        if (matchId == -1)
        {
            DeclareWinner();
        }
        
        Match match = _tournament.FindMatchById(matchId);
        MatchUIElement matchUI = _matchByIdMap[matchId];
        matchUI.pokemon1.SetPokemon(match.Pokemon1);
        matchUI.pokemon2.SetPokemon(match.Pokemon2);
    }

    private void DeclareWinner()
    {
        Debug.Log("***Winner is***");
        Debug.Log(_tournament.FindMatchById(_activeMatchId).Winner.Name);
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
