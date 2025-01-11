using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Create audio sound effects that will play throughout the game
    public AudioSource audioSource; // This is for the background tracks, and storing all the audios inside.
                                    // Basically an audio manager.
    public AudioClip shoot;
    public AudioClip hurt;
    public AudioClip objecthit;
    public AudioClip punch;

    public static SoundManager instance; 

    private void Awake() // When Unity itself is run
    {
        // Make sure there are no duplicates for the SoundManager instance
        if (instance == null)
        {
            instance = this; // this meaning itself
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Play sound effects once, at a specified volume (the second arguments)
    public void PlayShootSfx()
    {
        audioSource.PlayOneShot(shoot, 0.05f);
    }

    public void PlayHurtSfx()
    {
        audioSource.PlayOneShot(hurt);
    }

    public void PlayObjectHitSfx()
    {
        audioSource.PlayOneShot(objecthit); 
    }

    public void PlayPunchSfx()
    {
        audioSource.PlayOneShot(punch, 1.5f);
    }
}
