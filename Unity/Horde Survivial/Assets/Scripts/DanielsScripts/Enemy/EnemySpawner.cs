using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> easyEnemies, midEnemies, hardEnemies;
    public List<GameObject> enemyPool;
    public float EnemySpawnAdditionTimer = 0f;
    private GameObject player;

    public List<GameObject> spawners;

    public int EnemiesPerWave;
    public AnimationCurve spawnCurve;
    public float CurrentTime = 0;
    public float TotalTimeToProgress;

    private void Start()
    {
        enemyPool = new List<GameObject>();


        int enemyCount = easyEnemies.Count < EnemiesPerWave ? easyEnemies.Count : EnemiesPerWave;
        for (int i = 0; i < enemyCount; i++)
        {
            enemyPool.Add(easyEnemies[i]);
        }

        player = GameObject.FindWithTag("Player");

        StartCoroutine(SpawnEnemies());
        //create coroutine to keep adding enemies
    }

    public void Update()
    {
        EnemySpawnAdditionTimer += Time.deltaTime;
        if (EnemySpawnAdditionTimer > 30f)
        {
            if (EnemiesPerWave < 7)
            {
                EnemiesPerWave++;
                enemyPool.Add(midEnemies[Random.Range(0, midEnemies.Count)]);
            }

            EnemySpawnAdditionTimer = 0f;
        }
    }

    private void OnApplicationQuit()
    {
        easyEnemies = new List<GameObject>();
        midEnemies = new List<GameObject>();
        hardEnemies = new List<GameObject>();
    }

    IEnumerator SpawnEnemies()
    {
        while (CurrentTime < TotalTimeToProgress) 
        {
            float curveValue = spawnCurve.Evaluate(CurrentTime / TotalTimeToProgress);

            foreach(GameObject e in enemyPool)
            {
                for (int i = 0; i < e.GetComponent<Enemy>().AmountSpawnPerWave; i++)
                {
                    GameObject spawner = spawners[Random.Range(0, spawners.Count)];
                    Vector3 spawnPos = Vector3.zero;

                    if(spawner.name == spawners[0].name || spawner.name == spawners[2].name)
                    {
                        spawnPos = (new Vector3(0, Random.Range(-20, 20)) + spawner.transform.position);
                    } 
                    else if(spawner.name == spawners[1].name || spawner.name == spawners[3].name)
                    {
                        spawnPos = (new Vector3(Random.Range(-20, 20), 0) + spawner.transform.position);
                    }
                    
                    Instantiate(e, spawnPos, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(curveValue);

            CurrentTime += curveValue;

            CurrentTime = Mathf.Min(CurrentTime, TotalTimeToProgress);
        }
    }

    public void LeveledUp(int level)
    {

        //This number is the seconds between waves
        float sc = spawnCurve.Evaluate(CurrentTime / TotalTimeToProgress);

        if (player.GetComponent<LevelSystem>().level % 2 == 0)
        {
            if (sc > 2.5f && sc < 5)
            {
                enemyPool.Remove(enemyPool[Random.Range(0, enemyPool.Count)]);
                enemyPool.Add(hardEnemies[Random.Range(0, hardEnemies.Count)]);
                return;
            }

             enemyPool.Remove(enemyPool[Random.Range(0, enemyPool.Count)]);
             enemyPool.Add(midEnemies[Random.Range(0, midEnemies.Count)]);
        }
    }
}
