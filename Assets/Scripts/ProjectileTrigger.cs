using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    public float timeAlive = 2f;
    public string firedTag = "Player";
    public bool hasRigidbody = false;
    public GameObject afterEffect;

    private ParticleSystem projectilePS;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        projectilePS = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponent<ParticleSystem>().isPlaying && (other.tag != firedTag && other.tag != "Projectile"))
        {
            if (hasRigidbody)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }

            if (afterEffect != null)
            {
                Vector3 spawnPos = transform.position;
                spawnPos.y = 0.4f;
                GameObject projectileSummon = Instantiate(afterEffect, spawnPos, Quaternion.identity);
            }

            GetComponent<MeshRenderer>().enabled = false;
            projectilePS.Play();
        }
    }

    //Self Destruct
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
}
