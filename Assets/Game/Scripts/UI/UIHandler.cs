using UnityEngine;

namespace Runner.UI
{
    public class UIHandler : MonoBehaviour 
    {
        [SerializeField] private RectTransform _runnerPanel;
        [SerializeField] private RectTransform _paintPanel;
        [SerializeField] private RectTransform _gameFinishedPanel;

        private void Start() 
        {
            _runnerPanel.gameObject.SetActive(false);
            _paintPanel.gameObject.SetActive(false);
            _gameFinishedPanel.gameObject.SetActive(false);
            PhaseManager.onRunnerPhaseStart += RunnerPhaseUI;
            PhaseManager.onPaintingPhaseStart += PaintPhaseUI;
            PhaseManager.onGameFinished += GameFinishedUI;
        }

        private void RunnerPhaseUI()
        {
            _runnerPanel.gameObject.SetActive(true);
        }

        private void PaintPhaseUI()
        {
            _runnerPanel.gameObject.SetActive(false);
            _paintPanel.gameObject.SetActive(true);
        }

        private void GameFinishedUI()
        {
            _paintPanel.gameObject.SetActive(false);
            _gameFinishedPanel.gameObject.SetActive(true);
        }
    }
}