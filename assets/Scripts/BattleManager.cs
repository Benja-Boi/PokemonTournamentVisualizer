using System.Collections;
using System.Collections.Generic;
using DataTypes;
using UIElements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public TournamentManager tournamentManager;
    public BattlePokemonUIElement battlePlayer1;
    public BattlePokemonUIElement battlePlayer2;
    public Image player1Background;
    public Image player2Background;
    public Color backgroundColor1;
    public Color backgroundColor2;
    
    public void UpdateBattleUI(int matchId)
    {
        Match match = tournamentManager.FindMatchById(matchId);
        battlePlayer1.SetPokemon(match.Pokemon1);
        battlePlayer2.SetPokemon(match.Pokemon2);
        player1Background.color = backgroundColor1;
        player2Background.color = backgroundColor2;
    }
}
