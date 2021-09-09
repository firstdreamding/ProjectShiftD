using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpShot : ShootHandler
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Shoot(GameObject target)
    {
        Vector3 projection = (target.transform.position - transform.position);
        GameObject projectileSummon = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileSummon.GetComponent<ProjectileLauncher>().vectorMove = projection;
    }
}
