using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class SpriteDictionary : SerializableDictionary<string, Sprite> { }

public class BackgroundManager : MonoBehaviour
{
    public Image background;
    
    [SerializeField] public SpriteDictionary backgrounds = new SpriteDictionary();

    private void Awake()
    {
        SetStartScreenBackground();
    }

    private void SetBackground(string bg_name)
    {
        if (backgrounds.ContainsKey(bg_name))
        {
            background.sprite = backgrounds[bg_name];
        }
    }

    public void SetBattleBackground()
    {
        SetBackground("battle_bg");
    }
    
    public void SetOverviewBackground()
    {
        SetBackground("overview_bg");
    } 

    public void SetStartScreenBackground()
    {
        SetBackground("start_bg");
    }
}