using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TransitionManager : MonoBehaviour
{
    public Material transitionMaterial;
    public float transitionDuration;
    private float _transitionProgress = 0;
    private bool _isActiveTransition = false;
    private AnimationDirection _transitionDirection = AnimationDirection.Forward;

    private void Start()
    {
        SetMaterialTransitionValue();
    }

    private void Update()
    {
        if (_isActiveTransition)
        {
            _transitionProgress += ((int)_transitionDirection) * Time.fixedTime / transitionDuration;
            SetMaterialTransitionValue();
            if (_transitionProgress is < 1 and > 0) return;
            if (_transitionDirection == AnimationDirection.Forward)
            {
                _transitionDirection = AnimationDirection.Backwards;
            }
            else
            {
                _transitionDirection = AnimationDirection.Forward;
                _isActiveTransition = false;
            }
        }
    }

    private void SetMaterialTransitionValue()
    {
        transitionMaterial.SetFloat("Cutoff", _transitionProgress);
    }

    public void PlayTransition()
    {
        _isActiveTransition = true;
        _transitionDirection = AnimationDirection.Forward;
        _transitionProgress = 0;
    }

    enum AnimationDirection
    {
        Forward = -1,
        Backwards = 1
    }
}
