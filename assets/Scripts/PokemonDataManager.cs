﻿using System;
using UnityEngine;
using System.IO;
using DataTypes;

public class PokemonDataManager : MonoBehaviour
{
    public static PokemonDataManager Instance { get; private set; }
        
    public PokemonDatabase db;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public PokemonData GetPokemon(string pokemonName)
    {
        return db.GetPokemon(pokemonName);
    }
        
    public PokemonData GetPokemon(int pokemonNumber)
    {
        return db.GetPokemon(pokemonNumber);
    }
    
    public string GetRandomPokemonName()
    {
        return db.GetRandomPokemonName();
    }
}