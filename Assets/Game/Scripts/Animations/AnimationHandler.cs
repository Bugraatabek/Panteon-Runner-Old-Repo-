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
        //Competitor.onDeath += StartDeathAnimationRoutine;
        PhaseManager.onRunnerPhaseStart += RunnerAnimation;
        PhaseManager.onPaintingPhaseStart += PaintAnimation;
    }

    private void PaintAnimation()
    {
        _animator.SetBool("Idle", true);
        _animator.SetBool("Run", false);
    }

    private void RunnerAnimation()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", true);
    }
}
