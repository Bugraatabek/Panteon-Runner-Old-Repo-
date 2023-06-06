using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Collisions;
using UnityEngine;

    public class ScoreTracker : MonoBehaviour
    {
        private int _score;
        public int score { get {return _score;}}
        public event Action onScoreChange;

        void Awake()
        {
            _score = 0;
        }
            
        private void OnEnable() 
        {
            CoinCollisionHandler.onCoinCollect += OnCoinCollect;
        }

        private void OnCoinCollect()
        {
            _score += 5;
            if(onScoreChange != null)
            {
                onScoreChange();
            }
        }
    }

