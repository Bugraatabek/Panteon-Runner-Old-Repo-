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
                if(this.tag == "SpecialObstacle")
                {
                    this.GetComponent<ISpecialObstacle>().OnCollisionLogic(other.gameObject);
                    return;
                }
                other.GetComponent<ICompetitor>().OnCollison();
                if(this.GetComponent<ISpecialObstacle>() != null)
                {
                    this.GetComponent<ISpecialObstacle>().OnCollisionLogic(other.gameObject);
                }
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if(this.GetComponent<ISpecialObstacleRoutine>() != null)
            {
                this.GetComponent<ISpecialObstacleRoutine>().OnExitLogic();
            }
        }
    }
}
