using System.Collections;
using Runner.Control;
using UnityEngine;

namespace Runner.Obstacles
{
    public class RotatorObstacle : MonoBehaviour, ISpecialObstacleRoutine
    {
        private bool _shouldPush = false;
        [SerializeField] float _pushForce = 15f;

        public void OnCollisionLogic(GameObject competitor, Vector3 contactPoint)
        {
            Rigidbody competitorRB = competitor.GetComponent<Rigidbody>();
            StartCoroutine(StartPushing(competitorRB, contactPoint));
        }

        private IEnumerator StartPushing(Rigidbody competitorRB, Vector3 contactPoint)
        {
            contactPoint.y = 0;
            Vector3 force = -contactPoint;
            force.y = 0;
            _shouldPush = true;

            while(true)
            {
                competitorRB.AddForce(force * _pushForce, ForceMode.Impulse);
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