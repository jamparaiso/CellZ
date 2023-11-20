using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject",menuName ="ScriptableObject/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    //stats for enemies
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

    //add more stats or properties of enemy here
}
