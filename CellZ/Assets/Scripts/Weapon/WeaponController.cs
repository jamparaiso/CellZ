using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//weapon base class
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject weaponPrefab;
    public float damage;
    public float speed;
    public float coolDownDuration;
    private float currentCooldown;
    public int pierce;

    protected JoyStickController playerMovement;

    protected virtual void Awake()
    {
        
    }//Awake

    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<JoyStickController>();
        ResetCoolDown();
    }//Start

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f) 
        {
            Attack();
        }
    }//Update

    private void ResetCoolDown()
    {
        currentCooldown = coolDownDuration;
    }

    protected virtual void Attack()
    {
        ResetCoolDown();
    }

}//WeaponController
