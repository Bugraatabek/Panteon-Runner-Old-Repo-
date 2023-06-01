using System.Collections;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatorObstacle : MonoBehaviour, ISpecialObstacleRoutine
    {
        private bool shouldPush = false;

        public void OnCollisionLogic(GameObject competitor)
        {
            Rigidbody competitorRB = competitor.GetComponent<Rigidbody>();
            StartCoroutine(StartPushing(competitorRB));
        }

        private IEnumerator StartPushing(Rigidbody competitorRB)
        {
            shouldPush = true;
            while(true)
            {
                competitorRB.AddForce(Vector3.back * 100f, ForceMode.Impulse);
                //Vector3 pushDirection = new Vector3(transform.localPosition.x,0,0);
                
                if(shouldPush == false) yield break;
                yield return null;
            }
        }

        public void OnExitLogic()
        {
            shouldPush = false;
        }
    }
}