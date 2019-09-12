using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{

	public Camera c1, c2;

    // Start is called before the first frame update
    void Start()
    {
        c1.gameObject.SetActive(true);
        c2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            c1.gameObject.SetActive(!c1.gameObject.activeInHierarchy);
            c2.gameObject.SetActive(!c2.gameObject.activeInHierarchy);
        }
    }
}
