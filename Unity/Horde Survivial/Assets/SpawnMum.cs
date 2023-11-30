using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMum : MonoBehaviour
{
    public GameObject objectToSpawn;

    void Start()
    {
        // Start the coroutine to wait for 5 minutes before spawning the object
        StartCoroutine(SpawnObjectAfterDelay(300f)); // 300 seconds = 5 minutes
    }

    IEnumerator SpawnObjectAfterDelay(float delayInSeconds)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Spawn the game object
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
