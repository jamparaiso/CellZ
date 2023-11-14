using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float speed;

    private void Start()
    {
        player = FindObjectOfType<JoyStickController>().transform;
    }

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

}
