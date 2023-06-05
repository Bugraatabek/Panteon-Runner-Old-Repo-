using System;
using UnityEngine;
using UnityEngine.AI;

public class Competitor : MonoBehaviour, ICompetitor
{
    [SerializeField] private Transform _restartPoint;
    public static event Action onDeath;
    
    NavMeshAgent navMesh;
    Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>(); 
        navMesh = GetComponent<NavMeshAgent>();
        
    }

    public void OnCollison()
    {
        rb.isKinematic = true;
        navMesh.enabled = false;
        transform.position = _restartPoint.position;
        navMesh.enabled = true;
        rb.isKinematic = false;
        
    
        if(onDeath != null && this.gameObject.CompareTag("Player"))
        {
            onDeath();
        }
    }
}