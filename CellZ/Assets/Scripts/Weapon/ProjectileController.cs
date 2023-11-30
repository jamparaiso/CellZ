using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//inheriting class
public class ProjectileController : WeaponController
{

   protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject projectile;
        //projectile = Instantiate(weaponPrefab);
        projectile = PoolManager.Instantiate(weaponPrefab);
        projectile.transform.position = transform.position;
        projectile.GetComponent<ProjectileWeaponTypeBehavior>().DirectionChecker(playerMovement.moveDirection);
        projectile.GetComponent<ProjectileWeaponTypeBehavior>().Setup(playerMovement.moveDirection);
        projectile.SetActive(true);
    }


}
