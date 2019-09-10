using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int numberOfObjectToPool;


    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        } else{
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < numberOfObjectToPool; i++){
            GameObject obj = Instantiate(objectToPool) as GameObject;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject(){
        for (int i = 0; i < pooledObjects.Count; i++){
            if(!pooledObjects[i].activeInHierarchy){
                StartCoroutine(ReturnToPool(i));
                return pooledObjects[i];
            }
        }
        return null;
    }


    public float timeToDestroy = 3f;

    IEnumerator ReturnToPool(int pos)
    {
        yield return new WaitForSeconds(timeToDestroy);
        pooledObjects[pos].SetActive(false);
    }


}
