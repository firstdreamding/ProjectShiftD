using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateLeft()
    {
        transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
    }

    public void RotateRight()
    {
        transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
    }
}
