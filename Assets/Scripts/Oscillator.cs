using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movemnetFactor;
    Vector3 startingPosition; 

    void Start()
    {
        startingPosition = transform.position; // Check current position
    }

    void Update()
    {
        Vector3 Offeset = movementVector * movemnetFactor;
        transform.position = startingPosition + Offeset; // return the last position
    }
}
