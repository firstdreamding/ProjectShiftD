using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int hp = 10;
    public int current_hp;

    // Start is called before the first frame update
    void Start()
    {
        current_hp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Debug.Log("This");
            current_hp -= 1;
        }
    }
}
