using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 cameraOffset = new Vector3(0, 1.2f, -2.5f);

    public Transform target;

    private void Start()
    {
        if(target==null){
            //El game designer se ha olvidado de poner un objetivo para la camara
            //target = GameObject.Find("Player").transform;
            //target = GameObject.FindGameObjectWithTag("Player").transform;
            target = FindObjectOfType<CharacterController>().transform;
        }
    }

    private void LateUpdate()
    {
        this.transform.position = target.TransformPoint(cameraOffset);
        this.transform.LookAt(target);
    }
}
