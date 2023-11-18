using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waves
{
    [SerializeField] string waveName;
    public List<EnemyGroup> enemyGroup;
    public int spawnLimit;//total number of enemies to spawn in the current wave
    public int spawnCount; //total numbers of spawned enemies in the current wave
    public float spawnInterval = 2f;


}//class
