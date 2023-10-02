using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    //change in future to spawn faster as time goes on 
    private float spawnTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;   

        if(spawnTime <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnTime = 1.5f;
        }
    }
}
