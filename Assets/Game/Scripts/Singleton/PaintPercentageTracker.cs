using System;
using Runner.Painting;
using UnityEngine;

public class PaintPercentageTracker : MonoBehaviour 
{
    private static int _percentage;
    public static event Action onPercentageUpdate;

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
        
    }

    public static int GetPercentage()
    {
        return _percentage;
    }
}