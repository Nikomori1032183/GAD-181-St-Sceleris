using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiorandomiser : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold audio clips for randomization
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure there are audio clips assigned
        if (audioClips.Length == 0)
        {
            Debug.LogError("No audio clips assigned to " + gameObject.name);
            enabled = false; // Disable the script if no audio clips are assigned
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has a Rigidbody component (is interactable)
        if (other.GetComponent<BoxCollider>())
        {
            // Play a random audio clip from the array
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
        }
    }
}
