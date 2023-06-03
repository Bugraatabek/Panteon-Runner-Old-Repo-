using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Collisions
{
    public class CoinCollisionHandler : MonoBehaviour
    {
        public static event Action onCoinCollect;
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                if(onCoinCollect != null)
                {
                    onCoinCollect();
                }
            }
        }
    }
}
