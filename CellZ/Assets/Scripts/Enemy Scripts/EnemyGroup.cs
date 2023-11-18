using UnityEngine;

[System.Serializable]
public class EnemyGroup
{
    public string enemyName;
    public int toSpawn; //number of the same enemy type to be spawn in a wave
    public int totalSpawned; //number of enemies of the same type already spawned in a wave
    public GameObject enemyPrefab;

} //class
