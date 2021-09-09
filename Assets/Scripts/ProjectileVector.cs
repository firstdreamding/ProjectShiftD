using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileTrigger))]
public class ProjectileVector : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 vectorMove;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ParticleSystem>().isPlaying)
        {
            return;
        }

        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move

        transform.Translate(vectorMove * step);

    }
}

