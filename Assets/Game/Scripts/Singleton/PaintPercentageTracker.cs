using System;
using Runner.Painting;
using UnityEngine;

public class PaintPercentageTracker : MonoBehaviour 
{
    private int _percentage;
    public int percentage { get {return _percentage; } }
    public event Action onPercentageUpdate;
    public event Action onGameFinished;

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
}