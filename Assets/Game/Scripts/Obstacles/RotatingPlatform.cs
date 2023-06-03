using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatingPlatform : MonoBehaviour, ISpecialObstacleRoutine
    {
        private int _direction = -1;
        [Tooltip("checked = pushRight / unchecked = pushLeft")]
        [SerializeField] private bool _pushRight;
        [SerializeField] private float _pushForce = 100f; 
        private bool _shouldPush = false;
        
        private void Awake() 
        {
            if(_pushRight)
            {
                _direction = 1;
            }
            else
            {
                _direction = -1;
            }    
        }

        public void OnCollisionLogic(GameObject competitor, Vector3 contactPoint)
        {
            Rigidbody competitorRB = competitor.GetComponent<Rigidbody>();
            StartCoroutine(StartPushing(competitorRB));
        }

        private IEnumerator StartPushing(Rigidbody competitorRB)
        {
            _shouldPush = true;
            while(true)
            {
                competitorRB.AddForce(Vector3.right * _direction * _pushForce, ForceMode.VelocityChange);
                if(_shouldPush == false) yield break;
                yield return null;
            }
        }

        public void OnExitLogic()
        {
            _shouldPush = false;
        }
    }

}