using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyBehaviour : MonoBehaviour
{

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
