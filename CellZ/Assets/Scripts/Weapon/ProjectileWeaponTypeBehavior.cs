using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/// <summary>
/// Base script of all projectile based weapon
/// Plase this on weapon prefab of projectile type
/// </summary>
public class ProjectileWeaponTypeBehavior : MonoBehaviour
{
    protected Vector3 direction;
    [SerializeField]float destroyAfterSec;

    protected virtual void Start()
    {
        StartCoroutine(destroyProjectile());
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }

    IEnumerator destroyProjectile()
    {
        yield return new WaitForSeconds(destroyAfterSec);

        gameObject.SetActive(false);
    }

    public void Setup(Vector3 dir)
    {
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVector(dir));
    }
}
