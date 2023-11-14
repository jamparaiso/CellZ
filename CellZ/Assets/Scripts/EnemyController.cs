using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        this.gameObject.transform.position = player.position;
    }

}
