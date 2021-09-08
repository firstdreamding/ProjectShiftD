using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootHandler))]
public class BaseTowerScript : MonoBehaviour
{
    private List<GameObject> enemyList;
    private bool canShoot;

    public float delayInSeconds;

    private ShootHandler myShoot;
    void Start()
    {
        enemyList = new List<GameObject>();
        canShoot = true;

        myShoot = GetComponent<ShootHandler>();
    }

    void Update()
    {

        //This code right now targets the object that enters into the range first
        if (canShoot && enemyList.Count != 0)
        {
            OnFirstCome();
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

        //Shoots
        myShoot.Shoot(temp);

        canShoot = false;
        StartCoroutine(ShootDelay());
    }

    private void OnFirstCome()
    {
        int i = 0;
        while (enemyList.Count > i)
        {
            if (enemyList[i] == null)
            {
                enemyList.RemoveAt(i);
            } else
            {
                if (IsBlocked(enemyList[i]))
                {
                    Debug.Log(i + " is blocked");
                    i++;
                } else
                {
                    Debug.Log("FINE");
                    break;
                }
            }
        }

        if (enemyList.Count <= i)
        {
            return;
        }

        Debug.Log("Shoots!");
        //Shoots
        myShoot.Shoot(enemyList[i]);

        canShoot = false;
        StartCoroutine(ShootDelay());
    }

    private bool IsBlocked(GameObject target)
    {
        Vector3 dirToPlayer = (target.transform.position - transform.position);
        dirToPlayer.y = 0;
        dirToPlayer = dirToPlayer.normalized;


        int layerMask = 1 << 2;
        layerMask = ~layerMask;

        RaycastHit raycastHit;
        return Physics.Raycast(transform.position, dirToPlayer, out raycastHit, 1000, layerMask) && raycastHit.collider.tag != "Enemy";
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
