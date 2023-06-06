using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class DeathUI : MonoBehaviour 
    {
        [SerializeField] TextMeshProUGUI deathText;

        private void Start() 
        {
            Singleton.Instance.DeathTracker.onDeath += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            deathText.text = $"Death: {Singleton.Instance.DeathTracker.deathCount}";
        }
    }
}