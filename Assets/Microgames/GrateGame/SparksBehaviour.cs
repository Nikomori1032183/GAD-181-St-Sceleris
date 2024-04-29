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
        EventManager.current.onMicrogameStop += StopParticles;
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
        //Commented Out To Prevent Errors For Now
        //float pitch = Random.Range(0.9f, 1.1f);
        //sparksNoise.pitch = pitch;
        //sparksNoise.Play();
        //sparks.Play();
    }
    [Button]
    private void StopParticles()
    {
        //Commented Out To Prevent Errors For Now
        //sparksNoise.Stop();
        //sparks.Stop();
    }

    private void StopParticles(bool result)
    {
        //Commented Out To Prevent Errors For Now
        //sparksNoise.Stop();
        //sparks.Stop();
    }
}
