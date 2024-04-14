using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject emptyForSparks;
    private Vector3 mousePosition;
    [SerializeField] private ParticleSystem sparks;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.current.onLeftClickDown += StartParticles;
        InputManager.current.onLeftClickUp += StopParticles;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = InputManager.current.GetMousePosition();
        emptyForSparks.transform.position = mousePosition;
    }
    private void StartParticles()
    {
        if (sparks.isEmitting)
        {
            sparks.Play();
        }
    }
    private void StopParticles()
    {
        if (!sparks.isEmitting)
        {
            sparks.Stop();
        }
    }
}
