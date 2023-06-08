using System.Collections;
using System.Collections.Generic;
using DataTypes;
using UnityEngine;
using UnityEngine.Serialization;

public class BattleManager : MonoBehaviour
{
    public TournamentManager tournamentManager;
    public PokemonUIElement battlePlayer1;
    public PokemonUIElement battlePlayer2;

    public void UpdateBattleUI(int matchId)
    {
        Match match = tournamentManager.FindMatchById(matchId);
        battlePlayer1.SetPokemon(match.Pokemon1);
        battlePlayer2.SetPokemon(match.Pokemon2);
    }
}
