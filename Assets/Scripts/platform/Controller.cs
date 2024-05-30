using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<ShakeBlink> platforms; // List of platforms with ShakeBlink script

    void Start()
    {
        StartCoroutine(ManagePlatformMovements());
    }

    private IEnumerator ManagePlatformMovements()
    {
        // Wait for the initial 10 seconds
        yield return new WaitForSeconds(10.0f);

        // Stage 1: Shake and blink 2 platforms
        ShakeAndBlinkPlatforms(3);
        yield return new WaitForSeconds(15.0f);

        // Stage 2: Shake and blink 4 platforms
        ShakeAndBlinkPlatforms(6);
        yield return new WaitForSeconds(15.0f);

        // Stage 3: Shake and blink 6 platforms
        ShakeAndBlinkPlatforms(10);
    }

    private void ShakeAndBlinkPlatforms(int count)
    {
        List<ShakeBlink> availablePlatforms = new List<ShakeBlink>(platforms);
        int platformsToShake = Mathf.Min(count, availablePlatforms.Count);

        for (int i = 0; i < platformsToShake; i++)
        {
            int randomIndex = Random.Range(0, availablePlatforms.Count);
            ShakeBlink platform = availablePlatforms[randomIndex];
            platform.TriggerShakeAndBlink();
            availablePlatforms.RemoveAt(randomIndex);
        }
    }
}
