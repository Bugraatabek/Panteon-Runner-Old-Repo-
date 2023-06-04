using System;
using Runner.Collisions;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour 
{
    NavMeshAgent navMesh;
    Vector3 destination;
    [SerializeField] private float _range;

    private void Awake() 
    {
        navMesh = GetComponent<NavMeshAgent>();
        destination = FindObjectOfType<EndGameTrigger>().transform.position;
    }

    private void Update() 
    {
        CheckSurroundings();
        if(navMesh.isActiveAndEnabled)
        {
            navMesh.destination = destination;
        }
        
    }

    private void CheckSurroundings()
    {
        
    }

    // psuedo code
    // Same as playerController ai will start moving forward to End Game Trigger.
    // Every AI will have an invisible circle around it that will check the distance with surroundings.
    // If an AI gets close to an obstacle it will start moving the opposite side until it is safe.
    // Also every competitor can collide. When they collide they will push each other away.
}