using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

  // Parameters [Seri...]
  //Cache = Rigidbody rb;
  //State = variable
  [SerializeField] ParticleSystem mainBoosterParticle;
  [SerializeField] ParticleSystem leftBoosterParticle;
  [SerializeField] ParticleSystem rightBoosterParticle;

  [SerializeField] AudioClip mainEngine;

  [SerializeField] float mainThrust = 100f;
  [SerializeField] float rotationThrust = 1f;


    Rigidbody rb;
    AudioSource audioSource;


    void Start()
    {
      rb = GetComponent<Rigidbody>(); // remember always cache reference
      audioSource = GetComponent<AudioSource>(); // remember always cache reference
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else  //it must stay down than processThurust, because will conflict it
        {
            StopThrusting();
        }

    }

  void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartThrustingLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartThrustingRight();
        }

        else
        {
            StopThrustingBoth();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); // add force relative coordinate system

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine); // Play once audio clip
        }
        if (!mainBoosterParticle.isPlaying)
        {
            mainBoosterParticle.Play(); // fix the bug
        }
    }

      void StopThrusting()
    {
        audioSource.Stop();
        mainBoosterParticle.Stop();
    }

    void StartThrustingRight()
    {
        ApplyRotation(-rotationThrust); // with parameter 
        if (!rightBoosterParticle.isPlaying)
        {
            rightBoosterParticle.Play(); // fix the bug
        }
    }

    void StartThrustingLeft()
    {
        ApplyRotation(rotationThrust); // with parameter 
        if (!leftBoosterParticle.isPlaying)
        {
            leftBoosterParticle.Play(); // fix the bug
        }
    }

    void StopThrustingBoth()
    {
        rightBoosterParticle.Stop();
        leftBoosterParticle.Stop();
    }

    private void ApplyRotation(float rotationThisFrame) //  rename with new parameter 
    {
      rb.freezeRotation = true; // freezing rotation so we can mannually rotate
      transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
      rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }


}
