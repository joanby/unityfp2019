using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").
                                GetComponent<GameManager>();
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hemos entrado en un Item");
        if(other.gameObject.GetComponent<CharacterController>()!=null){
            gameManager.Items++;
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Estamos dentro de un Item");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Hemos salido de un Item");
    }




}
