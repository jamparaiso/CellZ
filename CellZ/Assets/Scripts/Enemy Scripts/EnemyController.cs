using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] EnemyScriptableObject enemyData;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<JoyStickController>().transform;
        
        
    }

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float randomNumber = UnityEngine.Random.Range(0f, 100f);


        foreach (var rate in enemyData.drops)
        {
            if(randomNumber <= rate.DropRate)
            {
                GameObject drop = PoolManager.instance.GetPooledObject(rate.DropPrefab);
                drop.transform.position = this.transform.position;
                drop.SetActive(true);
            }
            else
            {
                break;
            }
        }

        

    }

}
