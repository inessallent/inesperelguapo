using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour
{
    public AudioClip initialSound; // Initial sound to play when the game starts
    public AudioClip backgroundSound; // Background sound to play while playing
    public AudioClip pickUpSound; // Sound to play when the hand picks up the piece
    public AudioClip dropSound; // Sound to play when the hand drops the piece
    public AudioClip finalSound; // Final sound to play when the game ends

    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if an AudioSource component is attached
        if (audioSource == null)
        {
            // If not attached, add the AudioSource component
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Play the initial sound when the game starts
        if (initialSound != null)
        {
            audioSource.clip = initialSound;
            audioSource.Play();

            // Invoke the PlayBackgroundSound method after the initial sound has finished playing
            Invoke("PlayBackgroundSound", initialSound.length);
        }
        else
        {
            Debug.LogWarning("No initial sound assigned.");
        }
    }

    // Play the background sound
    void PlayBackgroundSound()
    {
        if (backgroundSound != null)
        {
            audioSource.clip = backgroundSound;
            audioSource.loop = true; // Loop the background sound
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No background sound assigned.");
        }
    }

    // Play the pick up sound
    public void PlayPickUpSound()
    {
        if (pickUpSound != null)
        {
            audioSource.clip = pickUpSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No pick up sound assigned.");
        }
    }

    // Play the drop sound
    public void PlayDropSound()
    {
        if (dropSound != null)
        {
            audioSource.clip = dropSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No drop sound assigned.");
        }
    }

    // Play the final sound
    public void PlayFinalSound()
    {
        if (finalSound != null)
        {
            audioSource.clip = finalSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No final sound assigned.");
        }
    }
}
