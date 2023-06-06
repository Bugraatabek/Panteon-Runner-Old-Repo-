using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick; // Reference to the joystick used for player control
        [SerializeField] private float _runSpeed = 2f; // Speed at which the player runs forward
        [SerializeField] private float _moveSideSpeed = 20f; // Speed at which the player moves sideways
        [SerializeField] private bool _shouldRun = false; // Flag indicating whether the player should be running

        private void OnEnable()
        {
            Singleton.Instance.PhaseManager.onRunnerPhaseStart += StartRunnerControls; // Subscribe to the onRunnerPhaseStart event
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += StopRunnerControls; // Subscribe to the onPaintingPhaseStart event
        }

        private void OnDisable() 
        {
            Singleton.Instance.PhaseManager.onRunnerPhaseStart -= StartRunnerControls; // Unsubscribe to the onRunnerPhaseStart event
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= StopRunnerControls; // Unsubscribe to the onPaintingPhaseStart event
        }

        private void StopRunnerControls()
        {
            _shouldRun = false; // Disable player running
        }

        private void StartRunnerControls()
        {
            _shouldRun = true; // Enable player running
        }

        private void FixedUpdate()
        {
            if (!_shouldRun) return; // If player should not run, exit the method

            // Move the player horizontally based on joystick input
            if (_joystick.Horizontal != 0)
            {
                transform.Translate(Vector3.right * _moveSideSpeed * _joystick.Horizontal * Time.fixedDeltaTime);
            }

            // Move the player forward at a constant speed
            transform.Translate(Vector3.forward * _runSpeed * Time.fixedDeltaTime);
        }
    }
}




// RigidBody Controls
// Vector3 currentPosition = transform.position + (Vector3.forward * _runSpeed * Time.fixedDeltaTime);
// if(_joystick.Horizontal != 0)
// {
//     currentPosition += (Vector3.right * _moveSideSpeed * _joystick.Horizontal * Time.fixedDeltaTime);
// }
// currentPosition.x = Mathf.Clamp(currentPosition.x, LevelBoundry.leftSideBoundry, LevelBoundry.rightSideBoundry);
// rb.MovePosition(currentPosition);
