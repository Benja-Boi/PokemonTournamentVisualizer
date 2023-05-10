using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataTypes;
using UnityEngine.UI;

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
    }

    public void GenerateTournamentUI(Tournament newTournament)
    {
        Tournament = newTournament;
        
        // Clear existing UI elements
        foreach (Transform child in roundsContainer)
        {
            Destroy(child.gameObject);
        }
        roundUIElements.Clear();

        // Generate UI elements for each match in the tournament
        TraverseAndGenerateUI(this.Tournament.FinalMatch);
    }

    private void TraverseAndGenerateUI(Match match)
    {
        if (match == null) return;

        // Instantiate a new RoundUIElement for the current round, if needed
        GameObject roundUIElement = GetOrCreateRoundUIElement(match.Round);

        // Instantiate a new MatchUIElement and set up its properties
        GameObject matchUIObject = Instantiate(matchUIElementPrefab, roundUIElement.transform);
        MatchUIElement matchUIElement = matchUIObject.GetComponent<MatchUIElement>();
        matchUIElement.matchId = match.ID;

        // Set up the UI Button click listener
        Button matchButton = matchUIObject.GetComponent<Button>();
        matchButton.onClick.AddListener(() => OnMatchButtonClick(matchUIElement.matchId));

        // Instantiate and set up PokemonUIElement objects for the participating Pokemon
        if (match.Pokemon1 != null)
        {
            GameObject pokemonUIObject1 = Instantiate(pokemonUIElementPrefab, matchUIObject.transform);
            PokemonUIElement pokemonUIElement1 = pokemonUIObject1.GetComponent<PokemonUIElement>();
            pokemonUIElement1.SetPokemon(match.Pokemon1);
        }
        if (match.Pokemon2 != null)
        {
            GameObject pokemonUIObject2 = Instantiate(pokemonUIElementPrefab, matchUIObject.transform);
            PokemonUIElement pokemonUIElement2 = pokemonUIObject2.GetComponent<PokemonUIElement>();
            pokemonUIElement2.SetPokemon(match.Pokemon2);
        }

        // Update the match UI state based on the current match state
        UpdateMatchUI(matchUIElement, match);

        // Traverse child nodes
        TraverseAndGenerateUI(match.PreviousMatch1);
        TraverseAndGenerateUI(match.PreviousMatch2);
    }

    private GameObject GetOrCreateRoundUIElement(int roundNumber)
    {
        if (roundUIElements.ContainsKey(roundNumber)) return roundUIElements[roundNumber];
        
        GameObject roundUIElement = Instantiate(roundUIElementPrefab, roundsContainer);
        roundUIElements[roundNumber] = roundUIElement;
        roundUIElement.name = "Round_" + roundNumber;

        return roundUIElements[roundNumber];
    }

    public void OnMatchButtonClick(int matchId)
    {
        Match clickedMatch = Tournament.FindMatchById(matchId);

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
            matchUIElement.SetState(MatchUIElement.MatchState.Available);
        }
        else if (match.IsComplete)
        {
            matchUIElement.SetState(MatchUIElement.MatchState.Completed);
            matchUIElement.SetWinner(match.Winner);
        }
        else
        {
            matchUIElement.SetState(MatchUIElement.MatchState.Unavailable);
        }
    }
}

internal class MatchUIElement
{
    public int matchId;
    public MatchState matchState;

    public void SetState(MatchState available)
    {
        matchState = available;
    }

    public class MatchState
    {
        public static MatchState Available { get; set; }
        public static MatchState Completed { get; set; }
        public static MatchState Unavailable { get; set; }
    }

    public void SetWinner(Pokemon matchWinner)
    {
        throw new System.NotImplementedException();
    }
}

internal class PokemonUIElement
{
    public void SetPokemon(Pokemon matchPokemon1)
    {
        throw new System.NotImplementedException();
    }
}
