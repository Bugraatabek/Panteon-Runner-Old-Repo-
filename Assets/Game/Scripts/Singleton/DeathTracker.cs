using System;
using UnityEngine;


public class DeathTracker : MonoBehaviour 
{
    private static int deathCount;
    public static event Action onDeath;


    private void Awake() 
    {
        deathCount = 0;
    }

    private void OnEnable() 
    {
        Competitor.onDeath +=  CountDeath;
    }

    private void CountDeath()
    {
        deathCount += 1;
        if(onDeath != null)
        {
            onDeath();
        }
    }

    public static int GetDeathCount()
    {
        return deathCount;
    }
}