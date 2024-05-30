using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plat"))
        {
            Destroy(gameObject); // Destroy the GameObject if it collides with an object tagged "plat"
        }
    }
}
