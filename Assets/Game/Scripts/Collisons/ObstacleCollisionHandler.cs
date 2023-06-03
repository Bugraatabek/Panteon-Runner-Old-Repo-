using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Collisions
{
    public class ObstacleCollisionHandler : MonoBehaviour
    {
        //Trigger
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
            {
                if(this.tag == "SpecialObstacle")
                {
                    this.GetComponent<ISpecialObstacle>().OnCollisionLogic(other.gameObject, new Vector3());
                    return;
                }
                if(this.GetComponent<ISpecialObstacle>() != null)
                {
                    this.GetComponent<ISpecialObstacle>().OnCollisionLogic(other.gameObject, new Vector3());
                }
                other.GetComponent<ICompetitor>().OnCollison();
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if(this.GetComponent<ISpecialObstacleRoutine>() != null)
            {
                this.GetComponent<ISpecialObstacleRoutine>().OnExitLogic();
            }
        }


        //Collider
        private void OnCollisionEnter(Collision other) 
        {
            if(other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
            {
                Vector3 contactPoint = other.GetContact(0).normal;
                if(this.tag == "SpecialObstacle")
                {
                    this.GetComponent<ISpecialObstacle>().OnCollisionLogic(other.gameObject, contactPoint);
                    return;
                }

                if(this.GetComponent<ISpecialObstacle>() != null)
                {
                    this.GetComponent<ISpecialObstacle>().OnCollisionLogic(other.gameObject, contactPoint);
                }
                other.transform.GetComponent<ICompetitor>().OnCollison();
                
            }
        }

        private void OnCollisionExit(Collision other) 
        {
            if(this.GetComponent<ISpecialObstacleRoutine>() != null)
            {
                this.GetComponent<ISpecialObstacleRoutine>().OnExitLogic();
            }
        }
    }
}
