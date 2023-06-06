using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Collisions;
using UnityEngine;

    public class ScoreTracker : MonoBehaviour
    {
        private static int score;
        public static event Action onScoreChange;

        void Awake()
        {
            score = 0;
        }
            
        private void OnEnable() 
        {
            CoinCollisionHandler.onCoinCollect += OnCoinCollect;
        }

        private void OnCoinCollect()
        {
            score += 5;
            if(onScoreChange != null)
            {
                onScoreChange();
            }
        }

        public static int GetScore()
        {
            return score;
        }
    }

