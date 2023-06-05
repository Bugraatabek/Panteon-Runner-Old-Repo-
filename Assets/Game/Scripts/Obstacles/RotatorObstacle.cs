using System.Collections;
using Runner.Control;
using UnityEngine;
using UnityEngine.AI;

namespace Runner.Obstacles
{
    public class RotatorObstacle : MonoBehaviour, ISpecialObstacle
    {
        
        [SerializeField] float _pushForce = 15f;

        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            contactPoint.y = 0;
            Vector3 forceDirection = -contactPoint;
            forceDirection.y = 0;
            competitorRB.AddForce(forceDirection * _pushForce, ForceMode.Impulse);
        }

       
    }
}