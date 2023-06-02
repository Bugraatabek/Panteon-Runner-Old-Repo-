using System;
using UnityEngine;

public class Competitor : MonoBehaviour, ICompetitor
{
    [SerializeField] private Transform _restartPoint;
    public static event Action onDeath;
    public void OnCollison()
    {
        transform.position = _restartPoint.position;
        if(onDeath != null && this.gameObject.tag == "Player")
        {
            onDeath();
        }
    }
}