using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    public GameObject projectile;
    public virtual void Shoot(GameObject target)
    {
        GameObject projectileSummon = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileSummon.GetComponent<ProjectileFollow>().target = target;
    }
}
