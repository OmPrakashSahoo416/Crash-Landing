using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementPos;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period=2f;

    private void Start()
    {
        startingPos = transform.position;
    }

    private void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float numberOfCycles = Time.time / period;
        const float tau = 2 * Mathf.PI;

        float randomSineWave = Mathf.Sin(tau * numberOfCycles);

        movementFactor = (randomSineWave + 1) / 2;

        transform.position = startingPos + movementPos * movementFactor; 
    }
}
