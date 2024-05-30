using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShakeBlink : MonoBehaviour
{
    public float shakeDuration = 10.0f;  // Duration of the shake
    public float shakeMagnitude = 0.1f;  // Magnitude of the shake
    public float initialBlinkFrequency = 1.0f; // Initial blink frequency
    public float finalBlinkFrequency = 0.1f; // Final blink frequency
    public string newTag = "plat"; // New tag to set when the platform becomes black

    private Vector3 originalPosition;
    private Renderer platformRenderer;
    private Color originalColor;
    private List<GameObject> objectsOnPlatform = new List<GameObject>(); // List to store objects on the platform

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition; // Store the original position of the platform
        platformRenderer = GetComponent<Renderer>(); // Get the Renderer component
        if (platformRenderer != null)
        {
            originalColor = platformRenderer.material.color; // Store the original color of the platform
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerShakeAndBlink();
        }
    }

    public void TriggerShakeAndBlink()
    {
        StartCoroutine(ShakeAndBlink());
    }

    private IEnumerator ShakeAndBlink()
    {
        float elapsed = 0.0f;
        bool isRed = false;
        float blinkFrequency = initialBlinkFrequency;

        while (elapsed < shakeDuration)
        {
            // Shake logic
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            // Blink logic
            if (platformRenderer != null)
            {
                platformRenderer.material.color = isRed ? originalColor : Color.red;
                isRed = !isRed;
            }

            elapsed += blinkFrequency;
            yield return new WaitForSeconds(blinkFrequency);

            // Update blink frequency to become faster over time
            float t = elapsed / shakeDuration;
            blinkFrequency = Mathf.Lerp(initialBlinkFrequency, finalBlinkFrequency, t);
        }

        // Finish with the platform's color turning black for 0.5 seconds
        if (platformRenderer != null)
        {
            platformRenderer.material.color = Color.black;
            gameObject.tag = newTag; // Change the tag of the platform
        }

        // Destroy all objects in the list
        foreach (var obj in objectsOnPlatform)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        objectsOnPlatform.Clear(); // Clear the list

        yield return new WaitForSeconds(0.5f);

        // Restore the original state
        transform.localPosition = originalPosition;
        if (platformRenderer != null)
        {
            platformRenderer.material.color = originalColor;
            gameObject.tag = "Untagged"; // Reset the tag to "Untagged"
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectsOnPlatform.Contains(other.gameObject))
        {
            objectsOnPlatform.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsOnPlatform.Contains(other.gameObject))
        {
            objectsOnPlatform.Remove(other.gameObject);
        }
    }
}

