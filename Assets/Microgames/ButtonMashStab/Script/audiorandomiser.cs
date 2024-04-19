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
    }

    void Update()
    {
        // Check if the object that collided has a Rigidbody component (is interactable)
        if (GetComponent<BoxCollider>())
        {
            // Play a random audio clip from the array
            painSource.clip = audioClips[Random.RandomRange(0, audioClips.Length)];
            painSource.Play();
        }
    }
}
