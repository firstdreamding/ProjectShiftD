using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            gameObject.GetComponent<CameraRotation>().RotateLeft();
        }

        if (Input.GetKeyDown("e"))
        {
            gameObject.GetComponent<CameraRotation>().RotateRight();
        }
    }
}
