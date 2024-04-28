using Bars;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class SparksBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject emptyForSparks;
    [SerializeField] private CutTheGrate gameRef;
    private Vector3 mousePosition;
    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private AudioSource sparksNoise;
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
        if (gameRef.gameDone)
        {
            sparks.Stop();
            sparksNoise.Stop();
        }
    }
    [Button]
    private void StartParticles()
    {
        sparksNoise.pitch = (Random.Range(0.9f, 1.1f));
        sparksNoise.Play();
        sparks.Play();
    }
    [Button]
    private void StopParticles()
    {
       sparksNoise.Stop();
       sparks.Stop();
    }
}
