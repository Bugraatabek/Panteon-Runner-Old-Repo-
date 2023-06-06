using System;
using System.Collections;
using Runner.Control;
using UnityEngine;

public class PhaseManager : MonoBehaviour 
{
    private bool _runnerPhase = false;
    public event Action onRunnerPhaseStart;
    public event Action onPaintingPhaseStart;
    public event Action onGameFinished;

    private void Start() 
    {
        Singleton.Instance.PaintPercentageTracker.onGameFinished += EndGame;
        StartCoroutine(GameLogic());
    }

    private void EndGame()
    {
        if(onGameFinished != null)
        {
            onGameFinished();
        }
    }

    private IEnumerator GameLogic()
    {
        while(true)
        {
            if(!_runnerPhase)
            {
                _runnerPhase = true;
                yield return new WaitForSeconds(3);
            }

            if(_runnerPhase)
            {
                RunnerPhase();
                yield break;
            }
        }
    }

    public void PaintingPhase()
    {
        if(onPaintingPhaseStart != null)
        {
            onPaintingPhaseStart();
        }
    }

    private void RunnerPhase()
    {
        if(onRunnerPhaseStart != null)
        {
            onRunnerPhaseStart();
        }
    }

}