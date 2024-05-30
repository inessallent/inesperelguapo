using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cruz : MonoBehaviour
{
    private Transform playerTransform;
    public Transform specificPosition; 

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("jugador"))
        {
            AttachToPlayer(other.transform);
        }
        else if (other.CompareTag("plat"))
        {
            PlaceOnSpecificPosition();
            DetachFromPlayer(); 
        }
    }

    private void AttachToPlayer(Transform player)
    {
        playerTransform = player;
        transform.SetParent(playerTransform);
    }

    private void DetachFromPlayer()
    {
        if (playerTransform != null)
        {
            transform.SetParent(null);
            playerTransform = null;
        }
    }

    private void PlaceOnSpecificPosition()
    {
        if (specificPosition != null)
        {
            transform.position = specificPosition.position;
            transform.rotation = specificPosition.rotation;
        }
        else
        {
            Debug.LogWarning("SpecificPosition is not assigned in the Inspector");
        }
    }

   
    public bool IsPlaced()
    {
        return transform.parent == null;
    }
}


