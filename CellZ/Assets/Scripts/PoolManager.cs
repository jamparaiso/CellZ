using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://medium.com/@maninduw/introduction-to-object-pooling-with-unity-9e38d24ec76a
public class PoolManager : MonoBehaviour
{
    // this could support several types of gameobjects and uses a prefabs InstanceID as a key
    Dictionary<int, List<GameObject>> poolDictionary = new Dictionary<int, List<GameObject>>();

    static PoolManager _instance;

    public static PoolManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PoolManager>();
            }
            return _instance;
        }
    }//PoolManager

    public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();

        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new List<GameObject>());

            for (int i = 0; i < poolSize; i++)
            {
                GameObject gameObject = Instantiate(prefab);
                gameObject.SetActive(false);
                poolDictionary[poolKey].Add(gameObject);
            }
        }
    }//CreatePool

    public GameObject GetPooledObject(GameObject prefab)
    {
        int poolKey = prefab.GetInstanceID();

        if (poolDictionary.ContainsKey(poolKey))
        {
            List<GameObject> pool = poolDictionary[poolKey];

            for(int i = 0;i < pool.Count;i++)
            {
                //checks if there is no active object in the pool
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    //return the inactive object
                    return pool[i];
                }
            }
            //if all object in the pool is active, create a new one and return the object
            GameObject gameObject = Instantiate(prefab);
            poolDictionary[poolKey].Add(gameObject);
            return gameObject;
        }
        return null;
    }//GetPooledObject

}//class
