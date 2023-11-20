using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] EnemyScriptableObject enemyData;
    [SerializeField] Transform player;

    private void Start()
    {
        player = FindObjectOfType<JoyStickController>().transform;
    }

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, player.position, enemyData.MoveSpeed * Time.deltaTime);
    }

}
