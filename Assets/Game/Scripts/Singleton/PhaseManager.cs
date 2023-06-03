using System;
using System.Collections;
using Runner.Control;
using UnityEngine;

public class PhaseManager : MonoBehaviour 
{
    private bool _runnerPhase = false;
    public static event Action onRunnerPhaseStart;
    public static event Action onPaintingPhaseStart;

    private void Start() 
    {
        StartCoroutine(GameLogic());
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

    public static void PaintingPhase()
    {
        if(onPaintingPhaseStart != null)
        {
            Debug.Log("Starting Painting Phase");
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