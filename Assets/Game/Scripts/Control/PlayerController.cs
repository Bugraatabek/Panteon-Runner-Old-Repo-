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
        
        void Update()
        {
            if(_joystick.Horizontal != 0)
            {
                transform.Translate(Vector3.right * _moveSideSpeed * _joystick.Horizontal * Time.deltaTime);
            }
            transform.Translate(Vector3.forward * _runSpeed * Time.deltaTime); 
           
            Vector3 currentPosition = transform.position;  
            currentPosition.x = Mathf.Clamp(currentPosition.x, LevelBoundry.Instance.leftSideBoundry, LevelBoundry.Instance.rightSideBoundry); 
            transform.position = currentPosition;
        }

        
    }
}
