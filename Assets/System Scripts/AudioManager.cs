using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class AudioManager : MonoBehaviour
{
    // Componenets
    AudioSource sfx;
    AudioSource music;

    // SFX
    [SerializeField] AudioClip buttonClickSFX, winSFX, loseSFX;

    // Music
    AudioClip mainMenu, track2, track3;

    private void Start()
    {
        // Components
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sfx = audioSources[0];
        music = audioSources[1];

        // Events
        EventManager.current.onMainMenuPlay += PlayButton;
        EventManager.current.onMicrogameStop += MicrogameFinished;
    }

    // Main Methods
    private void SetSFXSound(AudioClip clip)
    {
        sfx.clip = clip;
    }

    [Button]
    private void PlaySFXSound()
    {
        sfx.Play();
    }

    private void SetMusicTrack(AudioClip track)
    {
        music.clip = track;
    }

    [Button]
    private void PlayMusic()
    {
        music.Play();
    }

    [Button]
    private void StopMusic()
    {
        music.Stop();
    }

    // Music
    private void MainMenu()
    {
        SetMusicTrack(mainMenu);
        PlayMusic();
    }

    // SFX
    private void PlayButton()
    {
        SetSFXSound(buttonClickSFX);
        PlaySFXSound();
    }

    private void MicrogameFinished(bool result)
    {
        if (result)
        {
            SetSFXSound(winSFX);
        }

        else
        {
            SetSFXSound(loseSFX);
        }
        
        PlaySFXSound();
    }
}