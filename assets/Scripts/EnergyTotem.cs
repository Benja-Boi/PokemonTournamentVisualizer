using System;
using System.Collections;
using System.Collections.Generic;
using DataTypes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnergyTotem : MonoBehaviour
{
    public List<EnergyData> energiesData;
    public List<Image> totemSlots;
    public ParticleSystem megaHitParticles;
    private int _megaHitIndex = 0;

    private void Awake()
    {
        DisableMegaHit();
    }

    // Randomize the energy files between the totem slots
    public void RandomizeEnergies()
    {
        for (int i = 0; i < energiesData.Count; i++)
        {
            int randomIndex = Random.Range(0, energiesData.Count);
            (energiesData[i], energiesData[randomIndex]) = (energiesData[randomIndex], energiesData[i]);
        }
         
        for (int i = 0; i < energiesData.Count; i++)
        {
            totemSlots[i].sprite = energiesData[i].sprite;
        }
        
        _megaHitIndex = Random.Range(0, energiesData.Count);
        megaHitParticles.Play();

        var col = megaHitParticles.colorOverLifetime;
        col.enabled = true;
        col.color = GradidentFromColors(energiesData[_megaHitIndex].secondaryColor, energiesData[_megaHitIndex].primaryColor);
        megaHitParticles.transform.position = new Vector3(
            totemSlots[_megaHitIndex].transform.position.x,
            totemSlots[_megaHitIndex].transform.position.y,
            megaHitParticles.transform.position.z);
    }

    public void DisableMegaHit()
    {
        megaHitParticles.Stop();
    }

    private Gradient GradidentFromColors(Color color1, Color color2)
    {
        Gradient grad = new Gradient();
        grad.SetKeys( new GradientColorKey[]
        {
            new GradientColorKey(color1, 0.0f),
            new GradientColorKey(color2, 1.0f)
        }, new GradientAlphaKey[]
        {
            new GradientAlphaKey(1.0f,1.0f),
            new GradientAlphaKey(1.0f, 1.0f)
        } );

        return grad;
    }
}
