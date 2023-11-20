using System.Collections.Generic;
using UnityEngine;

//this class uses Unity's object pooling for memory usage optimisation
public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;

    [SerializeField] EnemySpawner enemySpawner;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<GameObject> enemyPrefabs;
    private int amountToPool; //set this amount to the total enemy to spawn from enemyspawner


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        enemyPrefabs = enemySpawner.enemyPrefabs;
        amountToPool = enemySpawner.maxPoolSize;

        foreach (GameObject enemyPrefab in enemyPrefabs) {

            for (int i = 0; i < amountToPool; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.SetActive(false);
                pooledObjects.Add(enemy);
            }
        }
    }//start

    public GameObject GetPooledObject() //make a controlled spawn by wave?
    {
        
        //for (int i = 0; i < pooledObjects.Count; i++)
        //{
        //    if (!pooledObjects[i].activeInHierarchy)
        //    {
        //        return pooledObjects[i];
        //    }
        //}
        //return null;    


        // Filter the list of pooled object and put all the inactive ones into a new list
        List<GameObject> inactiveObjects = pooledObjects.FindAll(go => !go.activeInHierarchy);

        //// Check if the list created above has elements
        //// If so, pick a random one,
        //// Return null otherwise
        return inactiveObjects.Count > 0 ?
            inactiveObjects[Random.Range(0, inactiveObjects.Count)] :
            null;
    }
}
