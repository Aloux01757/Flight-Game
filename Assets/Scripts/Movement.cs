using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime) ;
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust); // with parameter 
        }
        else if (Input.GetKey(KeyCode.D))
        {
          ApplyRotation(-rotationThrust); // with parameter 
        }
    }

    private void ApplyRotation(float rotationThisFrame) // with parameter 
    {
      rb.freezeRotation = true; // freezing rotation so we can mannually rotate
      transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
      rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }


}
