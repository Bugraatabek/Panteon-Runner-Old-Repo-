using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private float _runSpeed = 2f;
        [SerializeField] private float _moveSideSpeed = 20f;
        [SerializeField] private bool _shouldRun = false;

        private void Start() 
        {
            PhaseManager.onRunnerPhaseStart += StartRunnerControls;
            PhaseManager.onPaintingPhaseStart += StopRunnerControls;
        }

        private void StopRunnerControls()
        {
            _shouldRun = false;
        }

        private void StartRunnerControls()
        {
            _shouldRun = true;
            StartCoroutine(RunningRoutine());
        }

        private IEnumerator RunningRoutine()
        {
            while(true)
            {
                if(!_shouldRun) yield break;
                if(_shouldRun)
                {
                    if(_joystick.Horizontal != 0)
                    {
                        transform.Translate(Vector3.right * _moveSideSpeed * _joystick.Horizontal * Time.deltaTime);
                    }
                    transform.Translate(Vector3.forward * _runSpeed * Time.deltaTime); 
                
                    // Vector3 currentPosition = transform.position;  
                    // //currentPosition.x = Mathf.Clamp(currentPosition.x, LevelBoundry.leftSideBoundry, LevelBoundry.rightSideBoundry); 
                    // transform.position = currentPosition;
                }
                yield return null;
            }
        }

        public void SetRunSpeed(float value)
        {
            _runSpeed = value;
        }

        
    }
}
