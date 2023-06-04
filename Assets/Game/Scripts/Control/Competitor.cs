using System;
using UnityEngine;
using UnityEngine.AI;

public class Competitor : MonoBehaviour, ICompetitor
{
    [SerializeField] private Transform _restartPoint;
    public static event Action onDeath;
    
    NavMeshAgent navMesh;

    private void Awake() 
    {
        navMesh = GetComponent<NavMeshAgent>();
    }
    public void OnCollison()
    {
        navMesh.enabled = false;
        transform.position = _restartPoint.position;
        navMesh.enabled = true;
    
        if(onDeath != null && this.gameObject.tag == "Player")
        {
            onDeath();
        }
    }
}