using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner.Score.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;
        ScoreTracker scoreTracker;

        private void Awake() 
        {
            scoreTracker = FindObjectOfType<ScoreTracker>();
        }

        private void Start() 
        {
            UpdateUI();
        }

        private void OnEnable() 
        {
            scoreTracker.onScoreChange += UpdateUI;
        }

        private void UpdateUI()
        {
            scoreText.text = $"Score {scoreTracker.GetScore()}";
        }
    }
}
