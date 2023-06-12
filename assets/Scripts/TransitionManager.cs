using System.Collections.Generic;
using Game_Events;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public Material transitionMaterial;
    public float transitionDuration;
    public GameEvent[] transitionBlackScreenEvents;
    public List<Texture> transitionTextures;
    private float _transitionProgress = 0;
    private bool _isActiveTransition = false;
    private AnimationDirection _transitionDirection = AnimationDirection.Forward;
    private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");
    private int _currEvent = 0;
    
    private void Start()
    {
        SetMaterialTransitionValue();
    }

    private void Update()
    {
        if (_isActiveTransition)
        {
            _transitionProgress += ((int)_transitionDirection) * (Time.deltaTime / transitionDuration);
            SetMaterialTransitionValue();
            if (_transitionProgress is < 1 and > 0) return;
            if (_transitionDirection == AnimationDirection.Forward)
            {
                transitionBlackScreenEvents[_currEvent].Raise();
                _transitionDirection = AnimationDirection.Backwards;
                _transitionProgress = 1;
                _currEvent = (_currEvent + 1) % transitionBlackScreenEvents.Length;
            }
            else
            {
                _transitionDirection = AnimationDirection.Forward;
                _isActiveTransition = false;
                _transitionProgress = 0;
            }
        }
    }

    private void SetMaterialTransitionValue()
    {
        transitionMaterial.SetFloat(Cutoff, _transitionProgress);
    }

    public void PlayTransition()
    {
        transitionMaterial.SetTexture("_TransitionTex",GetRandomTransitionTexture());
        _isActiveTransition = true;
        _transitionDirection = AnimationDirection.Forward;
        _transitionProgress = 0;
    }

    private Texture GetRandomTransitionTexture()
    {
        return transitionTextures[Random.Range(0, transitionTextures.Count)];
    }

    public enum AnimationDirection
    {
        Forward = 1,
        Backwards = -1
    }
}
