using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject",menuName = "ScriptableObject/Player")]
public class PlayerScriptableObject : ScriptableObject
{

    //base stats for player
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

}

