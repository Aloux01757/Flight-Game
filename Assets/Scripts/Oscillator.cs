using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movemnetFactor; // Vai determinar o ponto de refereincia até o destino
    [SerializeField] float period = 2f;
    Vector3 startingPosition; 

    void Start()
    {
        startingPosition = transform.position; // Check current position
    }

    void Update()
    {
        float cycles = Time.time / period; // deixar crescendo no looping 
        const float tau = Mathf.PI * 2; // costante de valor 6.283 (Ciruculo completo)

        float rawSinWave = Mathf.Sin(cycles * tau); // -1 para 1

        movemnetFactor = (rawSinWave + 1f)  /2f; // recalcular 0 para 1


        Vector3 Offeset = movementVector * movemnetFactor;
        transform.position = startingPosition + Offeset; // return the last position
    }
}
