using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    
    [Header("Spawner Settings")]
    [SerializeField] GameObject player;
    [SerializeField] float spawnDistance = 30f;
    [SerializeField] float waveInterval = 1f;
    [SerializeField] EnemyPool enemyPool;
    public int maxPoolSize = 5;
    public List<GameObject> enemyPrefabs;

    private int currentWave;
    private float spawnTimer; //used for spawn interval of enemies

    public List<Waves> waves; //list of all waves in the game


    private void Start()
    {
        TotalEnemyCount();

    }//Start

    private void Update()
    {
        //if (!IsTotalSpawnedLimit())
        //{
        //    StartCoroutine(BeginNextWave());
        //}
        //else
        //{
            if (SpawnInterval())
            {
        //        SpawnEnemy();
                SpawnPooledEnemy();
            }
        //}

        //SpawnPooledEnemy();

    }//update

    IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if(currentWave < waves.Count -1)
        {
            currentWave++; //changing will also reset the spawnlimit
            TotalEnemyCount();
            Debug.Log("Starting Wave " + currentWave);
        }
    }//BeginNextWave

    private bool SpawnInterval()
    {
        //spawns the enemies based on their spawn interval value
        spawnTimer += Time.deltaTime;
        //float waveInterval = waves[currentWave].spawnInterval;

        if (spawnTimer > waveInterval)
        {
            spawnTimer = 0f;
            return true;
        }
        else
        {
            return false;
        }

    }//SpawnTimer

    private void SpawnPooledEnemy()
    {
        GameObject enemy = EnemyPool.instance.GetPooledObject();
        
        if (enemy != null)
        {
            enemy.transform.position = new Vector2(player.transform.position.x + Random.Range(-spawnDistance, spawnDistance),
                                                   player.transform.position.y + Random.Range(-spawnDistance, spawnDistance));
            enemy.SetActive(true);

        }
    }//SpawnPooledEnemy

    private void TotalEnemyCount()
    {
        //returns total enemies to spawn
        int enemyCount = 0;

        foreach (var enemyGroup in waves[currentWave].enemyGroup)
        {
            enemyCount += enemyGroup.toSpawn;
        }
        //used to stop the spawning of enemies
        waves[currentWave].spawnLimit = enemyCount;

    }//TotalEnemyCount

    private void SpawnEnemy()
    {
        if (IsTotalSpawnedLimit()){

            //spawn every type of enemy until the limit
            foreach(var enemyGroup in waves[currentWave].enemyGroup)
            {
                if(enemyGroup.totalSpawned < enemyGroup.toSpawn)
                {
                    Vector2 spawnPosition = new Vector2(player.transform.position.x + Random.Range(-spawnDistance, spawnDistance),
                                                        player.transform.position.y + Random.Range(-spawnDistance, spawnDistance));
                    
                    Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);

                    //update the counters
                    enemyGroup.totalSpawned++;
                    waves[currentWave].spawnCount++;
                }
            }
        }


        //spawn a random enemy from pooled enemy 

    }//SpawnEnemy


    private bool IsTotalSpawnedLimit()
    {
        //check the number of spawned enemies against the wave limit
        if (waves[currentWave].spawnCount < waves[currentWave].spawnLimit)
        {
            return true;
        }
        else
        {
            return false;
        }

    }//IsTotalSpawnLimit

}//class
