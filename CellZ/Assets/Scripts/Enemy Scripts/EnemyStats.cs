using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject enemyData;

    //current enemy stats
    private float currentMoveSpeed;
    private float currentHealth;
    private float currentDamage;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }


    //add functions or methods here that affects enemy stats e.g. take damage,slow down, etc.
}
