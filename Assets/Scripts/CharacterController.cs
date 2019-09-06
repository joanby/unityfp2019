using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private float hInput, vInput;

    public const string HORIZONTAL = "Horizontal", 
                        VERTICAL = "Vertical";


    [Range(0, 25)]
    [Tooltip("Velocidad de movimiento en m/s en el eje vertical")]
    public float moveSpeed;

    [Range(0, 360)]
    [Tooltip("Velocidad de rotación en grados/s en el eje horizontal")]
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis(HORIZONTAL);
        vInput = Input.GetAxis(VERTICAL);

        Debug.Log($"({hInput*turnSpeed},{vInput*moveSpeed})");

       

       
    }


    private void FixedUpdate()
    {
        //CINEMÁTICA
        //S = V * t * dy
        //theta = w * t * dx
        this.transform.Translate(Vector3.forward * vInput * moveSpeed * Time.fixedDeltaTime);
        this.transform.Rotate(Vector3.up * hInput * turnSpeed * Time.fixedDeltaTime);

    }
}


