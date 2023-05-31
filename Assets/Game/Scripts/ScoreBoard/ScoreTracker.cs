using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Collision;
using UnityEngine;

namespace Runner.Score
{
    public class ScoreTracker : MonoBehaviour
    {
        private int score;
        public event Action onScoreChange;
        
        private void OnEnable() 
        {
            CoinCollisionHandler.onCoinCollect += OnCoinCollect;
        }

        private void OnCoinCollect()
        {
            score += 1;
            onScoreChange();
        }

        public int GetScore()
        {
            return score;
        }
    }
}
