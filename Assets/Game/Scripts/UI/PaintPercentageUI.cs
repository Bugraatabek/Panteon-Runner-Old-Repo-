using System;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class PaintPercentageUI : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI percentageText;
        private void Start() 
        {
            Singleton.Instance.PaintPercentageTracker.onPercentageUpdate += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            percentageText.text = $"%{Singleton.Instance.PaintPercentageTracker.percentage}";
        }
    }
}