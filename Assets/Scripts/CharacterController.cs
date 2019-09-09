using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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

    public float jumpVelocity = 5f;


    //VARIABLES PARA EVITAR SALTOS INFINITOS
    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    private CapsuleCollider _col;


    //SHOOT VARIABLES
    public GameObject bullet;
    public float bulletSpeed = 100f;




    public float moveForce;
    public float turnForce;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
    
        //En el caso que la componente la tenga un hijo
        //this._rb = GetComponentInChildren<Rigidbody>();

        //En el caso que la componente la tenga el padre
        this._rb = GetComponent<Rigidbody>();

        //Detectamos la componente del collider 
        this._col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis(HORIZONTAL);
        vInput = Input.GetAxis(VERTICAL);

        //Debug.Log($"({hInput*turnSpeed},{vInput*moveSpeed})");

       

       
    }


    private void FixedUpdate()
    {
        //CINEMÁTICA
        //S = V * t * dy
        //theta = w * t * dx
        //this.transform.Translate(Vector3.forward * vInput * moveSpeed * Time.fixedDeltaTime);
        //this.transform.Rotate(Vector3.up * hInput * turnSpeed * Time.fixedDeltaTime);


        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }


        if(Input.GetMouseButtonDown(0)){

            GameObject newBullet = Instantiate(
                bullet,
                this.transform.position,//posicion del player
                this.transform.rotation //ángulo de rotación del player
            ) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;

        }



        //Cinemática con Rigidbody
        Vector3 rotation = Vector3.up * hInput*turnSpeed;
        Quaternion angleRotation = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + 
                         this.transform.forward * vInput * Time.fixedDeltaTime*moveSpeed);
        _rb.MoveRotation(_rb.rotation * angleRotation);

        /*
        _rb.AddForce(this.transform.forward * moveForce*vInput);
        _rb.AddTorque(this.transform.up * turnForce * hInput);
        */

    }



    private bool IsGrounded(){
        Vector3 capsuleBottom = new Vector3(
            _col.bounds.center.x,
            _col.bounds.min.y,
            _col.bounds.center.z
        );
        bool grounded = Physics.CheckCapsule(
            _col.bounds.center, capsuleBottom,
            distanceToGround, groundLayer, QueryTriggerInteraction.Ignore
        );

        return grounded;
    }
}


