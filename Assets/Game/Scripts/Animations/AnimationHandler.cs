using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator _animator;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();   
    }
    void Start()
    {
        PhaseManager.onRunnerPhaseStart += StartRunnerAnimation;
        PhaseManager.onPaintingPhaseStart += StartPaintAnimation;
    }

    private void StartPaintAnimation()
    {
        _animator.SetBool("Idle", true);
        _animator.SetBool("Run", false);
    }

    private void StartRunnerAnimation()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", true);
    }
}
