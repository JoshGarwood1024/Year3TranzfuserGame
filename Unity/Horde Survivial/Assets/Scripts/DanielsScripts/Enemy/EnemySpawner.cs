using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> easyEnemies, midEnemies, hardEnemies;
    public List<GameObject> enemyPool;

    private GameObject player;

    public List<GameObject> spawners;

    public AnimationCurve spawnCurve;
    public float CurrentTime = 0;
    public float TotalTimeToProgress;

    private void Start()
    {
        int enemyCount = easyEnemies.Count < 3 ? easyEnemies.Count : 3;

        for(int i = 0; i < enemyCount; i++)
        {
            enemyPool.Add(easyEnemies[Random.Range(0, easyEnemies.Count)]);
        }

        player = GameObject.FindWithTag("Player");

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (CurrentTime < TotalTimeToProgress && GameManager.Instance.State == GameState.Playing) 
        {
            float curveValue = spawnCurve.Evaluate(CurrentTime / TotalTimeToProgress);

            foreach(GameObject e in enemyPool)
            {
                for (int i = 0; i < e.GetComponent<Enemy>().AmountSpawnPerWave; i++)
                {
                    Vector3 spawnPos = (new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0) * 10) + spawners[i].transform.position;
                    Instantiate(enemyPool[Random.Range(0, enemyPool.Count)], spawnPos, Quaternion.identity);
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
            if (sc > 3.5f && sc < 3.95f)
            {
                enemyPool.Remove(enemyPool[Random.Range(0, enemyPool.Count)]);
                enemyPool.Add(midEnemies[Random.Range(0, midEnemies.Count)]);
                return;
            }

            if (sc > 2.5f)
            {
                enemyPool.Remove(enemyPool[Random.Range(0, enemyPool.Count)]);
                enemyPool.Add(hardEnemies[Random.Range(0, hardEnemies.Count)]);
            }
        }
    }
}
