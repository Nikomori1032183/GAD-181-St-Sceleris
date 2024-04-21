using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiorandomiser : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold audio clips for randomization
    private AudioSource painSource; // Reference to the AudioSource component

    void Start()
    {
        painSource = GetComponent<AudioSource>();

        if (painSource == null)
        {
            Debug.Log("No audio");
        }
    }



    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has a Rigidbody component (is interactable)
        if (other.GetComponent<Rigidbody>())
        {
            // Play a random audio clip from the array
            int randomIndex = Random.Range(0, audioClips.Length);
            painSource.clip = audioClips[randomIndex];
            painSource.Play();
        }
    }
}
