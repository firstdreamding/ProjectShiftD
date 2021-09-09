using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileTrigger))]
public class ProjectileLauncher : MonoBehaviour
{
    public float up = 3.0f;
    public Vector3 vectorMove;
    public float timeShot = 2.0f;
    public float finalSize = 0.8f;

    private Vector3 incrementPerSec;

    void Start()
    {
        //Make object traverse from point a to point b in time timeShot

        Debug.Log(vectorMove);
        vectorMove.x = vectorMove.x * 1.652f;
        vectorMove.y = -2 * Physics.gravity.y * timeShot;
        vectorMove.z = vectorMove.z * 1.652f;
        //Is the particle -> rigidbody -> add a force vector
        GetComponent<Rigidbody>().AddForce(vectorMove * 14);

        incrementPerSec = (new Vector3(finalSize, finalSize, finalSize) - transform.localScale) / timeShot;
    }

    private void Update()
    {
        if (transform.localScale.x >= finalSize)
        {
            Destroy(this);
        }
        transform.localScale += incrementPerSec * Time.deltaTime;
    }
}
