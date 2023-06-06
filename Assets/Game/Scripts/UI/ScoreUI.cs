using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI scoreText;


        private void Start() 
        {
            Singleton.Instance.ScoreTracker.onScoreChange += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = $"Score: {Singleton.Instance.ScoreTracker.score}";
        }
    }
}
