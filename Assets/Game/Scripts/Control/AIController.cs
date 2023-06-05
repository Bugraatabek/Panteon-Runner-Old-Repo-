using System;
using Runner.Collisions;
using UnityEngine;
using UnityEngine.AI;

namespace Runner.Control
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIController : MonoBehaviour, IAIController
    {
        NavMeshAgent navMesh;
        [SerializeField] Transform destinationPrefab; 
        [SerializeField] private bool _shouldRun = false;
        
        [SerializeField] private float _randomSteeringSpeedFloor = 17f;
        [SerializeField] private float _randomSteeringSpeedCeiling = 17.5f;
        private float _steerSpeed;

        private bool _shouldSteer = false;
        Vector3 _steerDirection;
        Vector3 destination;
        
    
        private void Awake() 
        {
            navMesh = GetComponent<NavMeshAgent>();
            destination = destinationPrefab.position;
            _steerSpeed = UnityEngine.Random.Range(_randomSteeringSpeedFloor,_randomSteeringSpeedCeiling);
        }

        private void Start() 
        {
            PhaseManager.onRunnerPhaseStart += StartRunnerControls;
            PhaseManager.onPaintingPhaseStart += StopRunnerControls;
        }

        private void FixedUpdate() 
        {
            
            if(!_shouldRun) return;
            if(navMesh.isActiveAndEnabled)
            {
                navMesh.destination = destination;
                if(_shouldSteer)
                {
                    transform.Translate(_steerDirection * _steerSpeed * Time.fixedDeltaTime);
                }
            }
        }

        private void StopRunnerControls()
        {
            _shouldRun = false;
        }

        private void StartRunnerControls()
        {
            _shouldRun = true;;
        }

        public void Steer(Vector3 direction)
        {
            _steerDirection = direction;
            _shouldSteer = true;
        }

        public void StopSteering()
        {
            _shouldSteer = false;
        }
    }
}