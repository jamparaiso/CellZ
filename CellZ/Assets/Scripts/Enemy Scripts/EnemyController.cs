using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //for enemy movement only
    //dont put other method that doesnt affect movement
    private Transform player;
    private EnemyStats enemyStats;

    private void Start()
    {
        player = FindObjectOfType<JoyStickController>().transform;
        enemyStats = GetComponent<EnemyStats>();
    }//Start

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.position, enemyStats.currentMoveSpeed * Time.deltaTime);
    }//Update

}//EnemyController
