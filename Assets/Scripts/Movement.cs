using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed SPACE - Flying");
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Rotating Left");
        }
         if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Rotating Right");
        }
    }
}
