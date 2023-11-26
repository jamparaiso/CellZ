using UnityEngine;

public class ChestStats : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject chestData;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = chestData.MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Chest Opened! Random drops!");
    }

}//ChestStats
