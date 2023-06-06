using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Collisions
{
    public class CoinCollisionHandler : MonoBehaviour
    {
        [SerializeField] RectTransform coinDestinationPos;
        [SerializeField] RectTransform coinSpawnPos;
        [SerializeField] GameObject uiCoinPrefab;
        
        public static event Action onCoinCollect;
        
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.tag == "Player")
            {
                if(onCoinCollect != null)
                {
                    onCoinCollect();
                }
                Destroy(gameObject);
                
            }
        }
    }
}
