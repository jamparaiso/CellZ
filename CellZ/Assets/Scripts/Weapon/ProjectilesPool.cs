using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    //this script is for creating and initialising projectiles into a pool

    [Header("Initialise all the projectiles in here")]
    [SerializeField] List<GameObject> projectilePrefab;
    [SerializeField] int amountToPool = 20;

    private void Start()
    {
        for (int i = 0; i < projectilePrefab.Count; i++)
        {
            PoolManager.instance.CreatePool(projectilePrefab[i], amountToPool);
        }
    }//Start
}
