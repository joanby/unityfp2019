using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public Transform theTransform;
    public Light theLight;

    public GameObject bullet;



    private GameObject[] allTheBullets;

    private int lastBullet;
    // Start is called before the first frame update
    void Start()
    {
        theTransform = this.gameObject.GetComponent<Transform>();
        //theTransform.position = new Vector3(0, 1, 1);

        theLight = GameObject.Find("Directional Light").GetComponent<Light>();
        //theLight = GameObject.FindObjectOfType<Light>();

        allTheBullets = new GameObject[100];
        for (int i = 0; i < 100; i++){
            allTheBullets[i] = Instantiate(bullet, this.transform.position, this.transform.rotation);
            allTheBullets[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            allTheBullets[lastBullet++].SetActive(true);
        }
    }
}
