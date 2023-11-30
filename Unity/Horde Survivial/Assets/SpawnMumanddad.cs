using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMumanddad : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn1;

    void Start()
    {
        // Start the coroutine to wait for 5 minutes before spawning the object
        StartCoroutine(SpawnObjectAfterDelay(900f)); // 300 seconds = 5 minutes
    }

    IEnumerator SpawnObjectAfterDelay(float delayInSeconds)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Spawn the game object
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        Instantiate(objectToSpawn1, transform.position, transform.rotation);
    }
}
