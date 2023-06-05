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
            if(other.gameObject.tag == "Player")
            {
                PhaseManager.PaintingPhase();
                other.transform.position = _paintingPhasePosition.position;
            }
        }
    }
}
