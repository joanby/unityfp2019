using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(SphereCollider))]
public class EnemyBehaviour : MonoBehaviour
{

    public Transform patrolRoute;

    public List<Transform> locations;

    private int currentLocation = 0;

    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute(){
        foreach(Transform t in patrolRoute){
            locations.Add(t);
        }
    }


    void MoveToNextPatrolLocation(){

        if(locations.Count==0){
            return;
        }

        _agent.destination = locations[currentLocation].position;

        currentLocation = (currentLocation + 1) % locations.Count;
    }

    private void Update()
    {
        if(_agent.remainingDistance < _agent.stoppingDistance &&
           !_agent.pathPending){
            MoveToNextPatrolLocation();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterController>()!=null){
            Debug.Log("Enemigo detectado. Atacar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterController>()!=null){
            Debug.Log("He perdido al enemigo de vista. Vuelta a la patrulla");
        }
    }

}
