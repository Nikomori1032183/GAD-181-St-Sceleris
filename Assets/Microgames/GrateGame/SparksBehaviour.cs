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
    [SerializeField] private float tempDeletMe = 0f;
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
        emptyForSparks.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - 12f)); ;
        Debug.Log("k");
        if (gameRef.gameDone)
        {
            sparks.Stop();
            sparksNoise.Stop();
        }
    }
    Vector3 FixedMouseInput()
    {
        //mousePosition.x = InputManager.current.GetMousePosition.x;
        //mousePosition.y = Camera.main.transform.position.y - 10;
        //mousePosition.z = InputManager.current.transform.position.y;
        return mousePosition;
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
    public void StopParticles()
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
