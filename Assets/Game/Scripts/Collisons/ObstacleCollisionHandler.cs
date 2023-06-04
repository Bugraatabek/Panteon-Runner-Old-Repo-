using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Collisions
{
    public class ObstacleCollisionHandler : MonoBehaviour
    {
        ISpecialObstacle iSpecialObstacle = null;
        ISpecialObstacleRoutine iSpecialObstacleRoutine = null;


        //Caching
        private void Awake() 
        {
            if(this.GetComponent<ISpecialObstacle>() != null)
            {
                iSpecialObstacle = GetComponent<ISpecialObstacle>();
            }

            if(this.GetComponent<ISpecialObstacleRoutine>() != null)
            {
                iSpecialObstacleRoutine = this.GetComponent<ISpecialObstacleRoutine>();
            }
        }
        
        //Trigger
        private void OnTriggerEnter(Collider other) 
        {
            Rigidbody competitorRB = other.gameObject.GetComponent<Rigidbody>();
            if(other.CompareTag("Player")  || other.CompareTag("AI"))
            {
                if(this.CompareTag("SpecialObstacle"))
                {
                    iSpecialObstacle.OnCollision(competitorRB, new Vector3());
                    return;
                }
                
                if(iSpecialObstacle != null)
                {
                    iSpecialObstacle.OnCollision(competitorRB, new Vector3());
                }

                other.GetComponent<ICompetitor>().OnCollison();
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if(iSpecialObstacleRoutine != null)
            {
                iSpecialObstacleRoutine.OnExit(other.gameObject.GetComponent<Rigidbody>());
            }
        }


        //Collision
        private void OnCollisionEnter(Collision other) 
        {
            Rigidbody competitorRB = other.gameObject.GetComponent<Rigidbody>();
            if(other.gameObject.CompareTag("Player")  || other.gameObject.CompareTag("AI"))
            {
                Vector3 contactPoint = other.GetContact(0).normal;
                if(this.tag == "SpecialObstacle" && iSpecialObstacle != null)
                {
                    iSpecialObstacle.OnCollision(competitorRB, contactPoint);
                    return;
                }

                if(iSpecialObstacle != null)
                {
                    iSpecialObstacle.OnCollision(competitorRB, contactPoint);
                }

                other.transform.GetComponent<ICompetitor>().OnCollison();
                
            }
        }

        private void OnCollisionExit(Collision other) 
        {
            if(iSpecialObstacleRoutine != null)
            {
                iSpecialObstacleRoutine.OnExit(other.gameObject.GetComponent<Rigidbody>());
            }
        }
    }
}
