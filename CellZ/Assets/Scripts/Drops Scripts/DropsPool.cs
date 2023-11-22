using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsPool : MonoBehaviour
{
    [Header("Initialise all the drops in here")]
    [SerializeField] List<GameObject> dropPrefabs;
    [SerializeField] int amountToPool = 20;

    private void Start()
    {
        for (int i = 0; i < dropPrefabs.Count; i++)
        {
            PoolManager.instance.CreatePool(dropPrefabs[i],amountToPool);
        }
    }

}//class