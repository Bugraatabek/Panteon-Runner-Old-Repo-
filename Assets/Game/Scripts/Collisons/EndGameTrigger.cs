using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Collisions
{
    public class EndGameTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _paintingPhasePosition; 
        private void OnTriggerEnter(Collider other) 
        {
            PhaseManager.PaintingPhase();
            if(other.gameObject.tag == "Player")
            {
                other.transform.position = _paintingPhasePosition.position;
            }

        }
    }
}
