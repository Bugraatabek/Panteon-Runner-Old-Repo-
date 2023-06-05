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
        [SerializeField] private float _pushForce; 

        List<Rigidbody> competitors = new List<Rigidbody>();
        List<IAIController> aIControllers = new List<IAIController>();
        
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


        private void FixedUpdate() 
        {
            if(competitors.Count == 0) return;
            
            foreach (var competitor in competitors)
            {
                competitor.AddForce(Vector3.right * _direction * _pushForce, ForceMode.VelocityChange);
            }
        }

        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            competitors.Add(competitorRB);
            if(competitorRB.CompareTag("Player")) return;
            competitorRB.GetComponent<IAIController>().Steer(Vector3.right * _direction * -1);
        }

        public void OnExit(Rigidbody rb)
        {
            competitors.Remove(rb);
            if(rb.CompareTag("Player")) return;
            rb.GetComponent<IAIController>().StopSteering();
        }
    }

}