using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 4f;

    private float currentSpawnTime, time;

    public List<GameObject> easyEnemies, midEnemies, hardEnemies;

    public List<GameObject> enemyPool;

    private GameObject player;

    public List<GameObject> spawners;

    public AnimationCurve spawnCurve;

    private void Start()
    {
        int enemyCount = easyEnemies.Count < 2 ? easyEnemies.Count : 2;

        for(int i = 0; i < enemyCount; i++)
        {
            enemyPool.Add(easyEnemies[i]);
        }

        player = GameObject.FindWithTag("Player");

        spawnTime = spawnCurve.Evaluate(Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if(spawnTime <= 0)
        {
            for(int i = 0; i < spawners.Count; i++)
            {
                Vector3 spawnPos = (new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0) * 10) + spawners[i].transform.position;
                GameObject enemyTemp = Instantiate(enemyPool[Random.Range(0, enemyPool.Count)], spawnPos, Quaternion.identity);
                spawnTime = spawnCurve.Evaluate(Time.time);
            }

        }
    }

    public void LeveledUp(int level)
    {
        if (player.GetComponent<LevelSystem>().level % 2 == 0)
        {
            if (currentSpawnTime > 0.7f)
            {
                currentSpawnTime -= 0.1f;
            }

            if(level >= 2 && level <= 8)
            {
                enemyPool.Remove(enemyPool[Random.Range(0, enemyPool.Count)]);
                enemyPool.Add(midEnemies[Random.Range(0, midEnemies.Count)]);
            }

            if (level > 8)
            {
                enemyPool.Remove(enemyPool[Random.Range(0, enemyPool.Count)]);
                enemyPool.Add(hardEnemies[Random.Range(0, midEnemies.Count)]);
            }
        }
    }
}
