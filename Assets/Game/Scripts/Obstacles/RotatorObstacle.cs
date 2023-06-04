using System.Collections;
using Runner.Control;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatorObstacle : MonoBehaviour, ISpecialObstacle
    {
        
        [SerializeField] float _pushForce = 15f;

        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            contactPoint.y = 0;
            Vector3 force = -contactPoint;
            force.y = 0;
            competitorRB.AddForce(force * _pushForce, ForceMode.Impulse);
        }
    }
}