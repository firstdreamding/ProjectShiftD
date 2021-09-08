using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour
{

    public GameObject target;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ParticleSystem>().isPlaying)
        {
            return;
        }

        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        if (target == null)
        {
            GetComponent<ParticleSystem>().Play();
        }

        //Try to delete it (possible for race condition)
        try
        {
            Vector3 targetVec = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetVec, step);
        } catch
        {
                GetComponent<ParticleSystem>().Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponent<ParticleSystem>().isPlaying && (other.tag == "Enemy" || other.tag == "Base"))
        {
            GetComponent<ParticleSystem>().Play();
        }
    }
}
