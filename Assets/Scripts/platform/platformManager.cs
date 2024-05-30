using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    public AudioClip initialSound; // Audio clip to play at the start
    public AudioClip backgroundSound; // Background sound to play after the initial sound
    public float gameStartDelay = 3f; // Delay before starting the game after background sound starts

    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
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

        // Check if an audio clip is assigned for the initial sound
        if (initialSound != null)
        {
            // Play the initial sound
            audioSource.clip = initialSound;
            audioSource.Play();

            // Start the background sound after the initial sound finishes
            StartCoroutine(StartBackgroundSoundDelayed(initialSound.length));
        }
        else
        {
            Debug.LogWarning("No initial sound assigned to platformManager.");
        }
    }

    // Coroutine to start the background sound after a delay
    IEnumerator StartBackgroundSoundDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Check if a background sound is assigned
        if (backgroundSound != null)
        {
            // Play the background sound
            audioSource.clip = backgroundSound;
            audioSource.loop = true; // Loop the background sound
            audioSource.Play();

            // Start the game after a delay
            yield return new WaitForSeconds(gameStartDelay);

            // Start the game (you can add your game start logic here)
            StartGame();
        }
        else
        {
            Debug.LogWarning("No background sound assigned to platformManager.");
        }
    }

    // Method to start the game (add your game start logic here)
    void StartGame()
    {
        Debug.Log("Game started!");
        // Add your game start logic here
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional logic here if needed
    }
}
