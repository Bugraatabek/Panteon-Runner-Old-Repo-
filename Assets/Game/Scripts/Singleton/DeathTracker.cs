using System;
using UnityEngine;


public class DeathTracker : MonoBehaviour 
{
    private int _deathCount;
    public int deathCount { get{ return _deathCount; } }
    public event Action onDeath;

    private void Awake() 
    {
        _deathCount = 0;
    }

    private void OnEnable() 
    {
        Competitor.onDeath +=  CountDeath;
    }

    private void CountDeath()
    {
        _deathCount += 1;
        if(onDeath != null)
        {
            onDeath();
        }
    }
}