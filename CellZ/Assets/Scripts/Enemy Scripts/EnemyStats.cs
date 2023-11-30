using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject enemyData;

    //current enemy stats
    public float currentMoveSpeed {  get; private set; }
    private float currentHealth;
    private float currentDamage;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }//Awake

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0) 
        {
            KillEnemy();
        }
    }//TakeDamage

    public void KillEnemy()
    {
        this.gameObject.SetActive(false);
        dropDrops();
    }//KillEnemy

    private void dropDrops()
    {
        float randomNumber = UnityEngine.Random.Range(0f, 100f);

        foreach (var rate in enemyData.drops)
        {
            if (randomNumber <= rate.DropRate)
            {
                GameObject drop = PoolManager.instance.GetPooledObject(rate.DropPrefab);
                drop.transform.position = this.transform.position;
                drop.SetActive(true);
            }
        }
    }//dropDrops

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //KillEnemy();
    }//OnCollisionEnter2D

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }//OnCollisionStay2D

    private void OnCollisionExit2D(Collision2D collision)
    {

    }//OnCollisionExit2D



    //add functions or methods here that affects enemy stats e.g. take damage,slow down, etc.
}
