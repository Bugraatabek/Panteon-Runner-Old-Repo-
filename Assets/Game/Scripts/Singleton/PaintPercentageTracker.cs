using System;
using Runner.Painting;
using UnityEngine;

public class PaintPercentageTracker : MonoBehaviour 
{
    private static int _percentage;
    public static event Action onPercentageUpdate;
    public static event Action onGameFinished;

    private void Awake() 
    {
        _percentage = 0;
    }

    private void OnEnable() 
    {
        Paintable.onPaint += UpdatePercentage;
    }

    private void UpdatePercentage()
    {
        _percentage += 1;
        if(onPercentageUpdate != null)
        {
            onPercentageUpdate();
        }
        if(_percentage == 100)
        {
            if(onGameFinished != null)
            {
                onGameFinished();
            }
        }
        
    }

    public static int GetPercentage()
    {
        return _percentage;
    }
}