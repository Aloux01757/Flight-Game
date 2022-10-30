using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

  // Parameters [Seri...]
  //Cache = Rigidbody rb;
  //State = variable
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      audioSource = GetComponent<AudioSource>();
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
          rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        
         if(!audioSource.isPlaying)
          {
            audioSource.PlayOneShot(mainEngine);
          }
        }
       else  //it must stay down than processThurust, because will conflict it
      {
        audioSource.Stop();
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
