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
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += StartRunnerControls;
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += StopRunnerControls;
        }

        private void StopRunnerControls()
        {
            _shouldRun = false;
        }

        private void StartRunnerControls()
        {
            _shouldRun = true;;
        }

        private void FixedUpdate() 
        {
            if(!_shouldRun) return;
            if(_joystick.Horizontal != 0)
            {
                Debug.Log("hi");
                transform.Translate(Vector3.right * _moveSideSpeed * _joystick.Horizontal * Time.fixedDeltaTime);
            }
            transform.Translate(Vector3.forward * _runSpeed * Time.fixedDeltaTime);


            // RigidBody Controls
            // Vector3 currentPosition = transform.position + (Vector3.forward * _runSpeed * Time.fixedDeltaTime);
            // if(_joystick.Horizontal != 0)
            // {
            //     currentPosition += (Vector3.right * _moveSideSpeed * _joystick.Horizontal * Time.fixedDeltaTime);
            // }
            // currentPosition.x = Mathf.Clamp(currentPosition.x, LevelBoundry.leftSideBoundry, LevelBoundry.rightSideBoundry);
            // rb.MovePosition(currentPosition);
        }
    }
            
}
