using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    //change in future to spawn faster as time goes on 
    private float spawnTime = 1.5f;

    private float currentSpawnTime = 1.5f;
    private float reduceSpawnTime = 5.0f;

    private float enemySpeed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            GameObject enemyTemp = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyTemp.GetComponent<EnemyChase>().speed = enemySpeed;
            spawnTime = currentSpawnTime;
        }

        if (reduceSpawnTime <= 0 && currentSpawnTime >= 0.5f)
        {
            currentSpawnTime -= 0.1f;
            reduceSpawnTime = 5.0f;
            enemySpeed += 0.3f;
        } else
        {
            reduceSpawnTime -= Time.deltaTime;
        }

    }
}
