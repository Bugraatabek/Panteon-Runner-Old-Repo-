using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Collision
{
    public class ObstacleCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
            {
                
            }
        }
    }
}
