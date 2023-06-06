using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Anim
{
    public class AnimationHandler : MonoBehaviour
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void OnEnable()
        {
            // Subscribe to the onRunnerPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += RunnerAnimation;

            // Subscribe to the onPaintingPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += PaintAnimation;
        }
        
        private void OnDisable() 
        {
            // Unsubscribe to the onRunnerPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onRunnerPhaseStart -= RunnerAnimation;

            // Unsubscribe to the onPaintingPhaseStart event in the PhaseManager
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= PaintAnimation;    
        }

        private void PaintAnimation()
        {
            // Set the "Idle" parameter to true to trigger the idle animation
            _animator.SetBool("Idle", true);

            // Set the "Run" parameter to false to stop the running animation
            _animator.SetBool("Run", false);
        }

        private void RunnerAnimation()
        {
            // Set the "Idle" parameter to false to stop the idle animation
            _animator.SetBool("Idle", false);

            // Set the "Run" parameter to true to trigger the running animation
            _animator.SetBool("Run", true);
        }
    }    
}
