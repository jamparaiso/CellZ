using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCellBehavior : ProjectileWeaponTypeBehavior
{
    ProjectileController weaponController;

    protected override void Start()
    {
        base.Start();
        weaponController = FindObjectOfType<ProjectileController>();
    }

    private void Update()
    {
        moveProjectile(direction);
        
    }

    private void moveProjectile(Vector3 dir)
    {
        transform.position += (dir * weaponController.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyStats>().TakeDamage(weaponController.damage);
            this.gameObject.SetActive(false);
        }
    }

}
