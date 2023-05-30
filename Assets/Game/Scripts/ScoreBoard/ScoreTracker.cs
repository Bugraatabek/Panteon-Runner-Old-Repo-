using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Collision;
using UnityEngine;

namespace Runner.Score
{
    public class ScoreTracker : MonoBehaviour
    {
        List<CoinCollisionHandler> coinCollisionHandlers;
        private int score;
        public event Action onScoreChange;

        private void Awake() 
        {
            coinCollisionHandlers = new List<CoinCollisionHandler>();
            foreach (var coinCollisionHandler in FindObjectsOfType<CoinCollisionHandler>())
            {
                coinCollisionHandlers.Add(coinCollisionHandler);
            }
        }

        private void OnEnable() 
        {
            foreach (var coin in coinCollisionHandlers)
            {
                coin.onCoinCollect += OnCoinCollect;
            }
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
