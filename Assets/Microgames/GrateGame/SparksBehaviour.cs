using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

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
        //Debug.Log(mousePosition);
        emptyForSparks.transform.position = mousePosition;
        //Debug.Log(emptyForSparks.transform.position);
    }
    [Button]
    private void StartParticles()
    {
        sparks.Play();
    }
    [Button]
    private void StopParticles()
    {
       sparks.Stop();
    }
}
