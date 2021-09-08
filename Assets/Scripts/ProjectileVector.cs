using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVector : MonoBehaviour
{
    public float speed = 1.0f;
    public float timeAlive = 10f;
    public Vector3 vectorMove;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
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

        //Try to delete it (possible for race condition)
        try
        {
            transform.Translate(vectorMove * step);
        }
        catch
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

    //Self Destruct
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
}
