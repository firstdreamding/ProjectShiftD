using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTowerScript : MonoBehaviour
{
    private List<GameObject> enemyList;
    private bool canShoot;

    public float delayInSeconds;
    public GameObject projectile;
    void Start()
    {
        enemyList = new List<GameObject>();
        canShoot = true;
    }

    void Update()
    {

        //This code right now targets the object that enters into the range first
        if (canShoot && enemyList.Count != 0)
        {
            OnHighHP();
        }

    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

    private void OnHighHP()
    {
        GameObject temp = null;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] != null)
            {
                if (temp == null || temp.GetComponent<EnemyScript>().hp < enemyList[i].GetComponent<EnemyScript>().hp)
                {
                    temp = enemyList[i];
                }
            }
        }

        if (temp == null)
        {
            return;
        }

        GameObject projectileSummon = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileSummon.GetComponent<ProjectileFollow>().target = temp;

        canShoot = false;
        StartCoroutine(ShootDelay());
    }

    private void OnFirstCome()
    {
        while (enemyList.Count != 0 && enemyList[0] == null)
        {
            enemyList.RemoveAt(0);
        }
        if (enemyList.Count == 0)
        {
            return;
        }

        Debug.Log("Shoots!");

        GameObject projectileSummon = Instantiate(projectile, transform.position, Quaternion.identity);
        projectileSummon.GetComponent<ProjectileFollow>().target = enemyList[0];

        canShoot = false;
        StartCoroutine(ShootDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !enemyList.Contains(other.gameObject))
        {
            Debug.Log("test");
            enemyList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy" && enemyList.Contains(other.gameObject))
        {
            enemyList.Remove(other.gameObject);
        }
    }
}
