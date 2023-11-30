using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMumanddad3 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn2;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn4;
    public GameObject objectToSpawn5;
    public GameObject objectToSpawn6;
    public GameObject objectToSpawn7;

    void Start()
    {
        // Start the coroutine to wait for 5 minutes before spawning the object
        StartCoroutine(SpawnObjectAfterDelay(1500f)); // 300 seconds = 5 minutes
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
        Instantiate(objectToSpawn4, transform.position, transform.rotation);
        Instantiate(objectToSpawn5, transform.position, transform.rotation);
        Instantiate(objectToSpawn6, transform.position, transform.rotation);
        Instantiate(objectToSpawn7, transform.position, transform.rotation);
    }
}
