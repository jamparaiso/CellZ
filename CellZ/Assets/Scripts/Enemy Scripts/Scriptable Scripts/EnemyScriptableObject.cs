using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject",menuName ="ScriptableObject/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    //base stats of enemies
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }


    [System.Serializable]
    public class DropList
    {
        [SerializeField] GameObject dropPrefab;
        public GameObject DropPrefab { get => dropPrefab; set => dropPrefab = value; }

        [SerializeField] float dropRate;
        public float DropRate { get => dropRate; set => dropRate = value; }
    }//DropList

    public List<DropList> drops;


    //add more stats or properties of enemy here


}//ScriptableObject
