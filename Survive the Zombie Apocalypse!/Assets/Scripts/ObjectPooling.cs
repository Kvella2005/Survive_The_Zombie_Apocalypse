using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject poolingObject;

    public int PoolCount = 20;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < PoolCount; i++)
        {
            GameObject tmp = Instantiate(poolingObject);
            tmp.SetActive(false);
            tmp.transform.SetParent(this.transform);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PoolCount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
