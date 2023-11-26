using System.Collections.Generic;
using UnityEngine;

public class DropsPool : MonoBehaviour
{
    //this script is for creating initialising drops into a pool

    [Header("Initialise all the drops in here")]
    [SerializeField] List<GameObject> dropPrefabs;
    [SerializeField] int amountToPool = 20;

    private void Start()
    {
        for (int i = 0; i < dropPrefabs.Count; i++)
        {
            PoolManager.instance.CreatePool(dropPrefabs[i],amountToPool);
        }
    }//Start

}//class
