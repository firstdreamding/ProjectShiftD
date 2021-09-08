using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupShot : ShootHandler
{
    public float angle;
    public int amount;

    public void Start()
    {
        if (amount % 2 == 0)
        {
            amount += 1;
            Debug.LogError("Needs to be odd");
        }
    }

    public override void Shoot(GameObject target)
    {
        Vector3 projection = (target.transform.position - transform.position).normalized;

        for (int i = -1 * amount/2; i <= amount/2; i++)
        {
            GameObject projectileSummon = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileSummon.GetComponent<ProjectileVector>().vectorMove = Quaternion.AngleAxis(angle * i, Vector3.up) * projection;
        }
    }
}
