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
            PaintPercentageTracker.onPercentageUpdate += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            percentageText.text = $"%{PaintPercentageTracker.GetPercentage()}";
        }
    }
}