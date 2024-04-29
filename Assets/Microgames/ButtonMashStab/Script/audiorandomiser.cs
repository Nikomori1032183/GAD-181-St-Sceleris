using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiorandomiser : MonoBehaviour
{
    public AudioClip[] audioClips; 
    private AudioSource painSource; 

    void Start()
    {
        painSource = GetComponent<AudioSource>();

        if (painSource == null)
        {
            Debug.Log("No audio");
        }
    }



    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            
            int randomIndex = Random.Range(0, audioClips.Length);
            painSource.clip = audioClips[randomIndex];
            painSource.Play();

            Debug.Log(painSource.clip);
        }
    }
}
