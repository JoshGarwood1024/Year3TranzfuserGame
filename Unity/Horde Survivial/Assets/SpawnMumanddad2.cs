using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMumanddad2 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;

    void Start()
    {
        // Start the coroutine to wait for 5 minutes before spawning the object
        StartCoroutine(SpawnObjectAfterDelay(1200f)); // 300 seconds = 5 minutes
    }

    IEnumerator SpawnObjectAfterDelay(float delayInSeconds)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayInSeconds);

        // Spawn the game object
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        Instantiate(objectToSpawn1, transform.position, transform.rotation);
        Instantiate(objectToSpawn2, transform.position, transform.rotation);
        Instantiate(objectToSpawn3, transform.position, transform.rotation);
    }
}
