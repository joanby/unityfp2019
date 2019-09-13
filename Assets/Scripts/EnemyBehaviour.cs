using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(SphereCollider))]
public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;

    public Transform patrolRoute;

    public List<Transform> locations;

    private int currentLocation = 0;

    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player").transform;

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
            _agent.destination = player.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            _agent.destination = player.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<CharacterController>()!=null){
            Debug.Log("He perdido al enemigo de vista. Vuelta a la patrulla");
            MoveToNextPatrolLocation();
        }
    }

}
