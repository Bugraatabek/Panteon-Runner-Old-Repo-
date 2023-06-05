using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Control;
using UnityEngine;

namespace Runner.Collisions
{
    public class EndGameTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _paintingPhasePosition;
        private void OnTriggerEnter(Collider other) 
        {
            if(other.CompareTag("AI"))
            {
                other.gameObject.SetActive(false);
                return;
            }

            if(other.CompareTag("Player"))
            {
                foreach (var ai in FindObjectsOfType<AIController>())
                {
                    ai.gameObject.SetActive(false);
                } 

                PhaseManager.PaintingPhase();
                other.transform.position = _paintingPhasePosition.position;
            }
        }
    }
}
