using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follows : MonoBehaviour
{
    public Transform target; // Reference to the GameObject (e.g., player) that the Hands will follow
    private puzzleManager manager;


/*    void Start()
    {
        manager = FindObjectOfType<puzzleManager>();
        if (manager == null)
        {
            Debug.LogWarning("No se encontró el puzzleManager en la escena.");
        }
    }*/

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
        else
        {
            Debug.LogWarning("Target is not assigned. Hands cannot follow.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cruz"))
        {
            // Cuando las manos tocan una pieza, reproducir el sonido de recogida
            if (manager != null)
            {
                manager.PlayPickUpSound();
            }
            else
            {
                Debug.LogWarning("No se encontró el puzzleManager para reproducir el sonido de recogida.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cruz"))
        {
            // Cuando las manos dejan de tocar una pieza, reproducir el sonido de soltar
            if (manager != null)
            {
                manager.PlayDropSound();
            }
            else
            {
                Debug.LogWarning("No se encontró el puzzleManager para reproducir el sonido de soltar.");
            }
        }
    }
}


