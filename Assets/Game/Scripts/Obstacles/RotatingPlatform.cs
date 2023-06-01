using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatingPlatform : MonoBehaviour, ISpecialObstacleRoutine
    {
        [SerializeField] private int _direction = -1;
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
                competitorRB.AddForce(Vector3.right * _direction * 5f, ForceMode.VelocityChange);
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