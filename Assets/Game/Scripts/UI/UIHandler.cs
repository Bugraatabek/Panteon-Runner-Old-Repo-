using UnityEngine;

namespace Runner.UI
{
    public class UIHandler : MonoBehaviour 
    {
        [SerializeField] private RectTransform _runnerPanel;
        [SerializeField] private RectTransform _paintPanel;

        private void Start() 
        {
            _runnerPanel.gameObject.SetActive(false);
            _paintPanel.gameObject.SetActive(false);
            PhaseManager.onRunnerPhaseStart += HandleJoystickUI;
            PhaseManager.onPaintingPhaseStart += HandlePaintUI;
        }

        private void HandleJoystickUI()
        {
            _runnerPanel.gameObject.SetActive(true);
        }

        private void HandlePaintUI()
        {
            _runnerPanel.gameObject.SetActive(false);
            _paintPanel.gameObject.SetActive(true);
        }
    }
}