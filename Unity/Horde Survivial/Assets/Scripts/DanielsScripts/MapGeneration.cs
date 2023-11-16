using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneration : MonoBehaviour
{
    int[,] generatedMap;

    public int width;
    public int height;

    public RuleTile tile, BGTile;
    public Tilemap backgroundTileMap;
    public List<Tile> trees;

    public GameObject player;

    public string seed;
    private System.Random pseudoRandom;

    [Range(0, 100)]
    public int fillingPercentage;

    public List<GameObject> EnemySpawners = new List<GameObject>();

    void Start()
    {
        seed = Random.Range(1, 9999999).ToString();

        CellularAutomata();
        DrawMap();

        for(int x = (width/2)-5; x < (width/2)+5; x++)
        {
            for (int y = (height / 2) - 5; y < (height / 2) + 5; y++)
            {
                if(generatedMap[x, y] == 1)
                {
                    player.transform.position = new Vector3(x, y);
                    Camera.main.transform.position = player.transform.position;
                    break; 
                }
            }
        }

        SpawnEnemySpawners();
        GameManager.Instance.UpdateGameState(GameState.Playing);
    }

    void CellularAutomata()
    {
        seed = (seed.Length <= 0) ? Time.time.ToString() : seed;
        pseudoRandom = new System.Random(seed.GetHashCode());

        GenerateMap();

        for (int i = 0; i < 5; i++)
            SmoothMap();

        RemoveSecludedCells();
        RecoverEdgeCells();
    }

    void GenerateMap()
    {
        generatedMap = new int[width, height];

        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                generatedMap[x, y] = (pseudoRandom.Next(0, 100) < fillingPercentage) ? 1 : 0;
            }
        }
    }

    int getNeighboursCellCount(int x, int y, int[,] map)
    {
        int neighbors = 0;
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                neighbors += map[i + x, j + y];

        neighbors -= map[x, y];

        return neighbors;
    }

    void SmoothMap()
    {
        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                int neighbors = getNeighboursCellCount(x, y, generatedMap);

                if (neighbors > 4)
                    generatedMap[x, y] = 1;
                else if (neighbors < 4)
                    generatedMap[x, y] = 0;
            }
        }
    }

    void RecoverEdgeCells()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    generatedMap[x, y] = 0;
            }
        }
    }

    void RemoveSecludedCells()
    {
        for (int x = 1; x < width - 1; x++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                generatedMap[x, y] = (getNeighboursCellCount(x, y, generatedMap) <= 0) ? 0 : generatedMap[x, y];
            }
        }

    }

    void DrawMap()
    {
        //Draws background
        for (int _x = -20; _x < width + 20; _x++)
        {
            for(int _y = -20; _y < height + 20; _y++)
            {
                Vector3 pos = new Vector3(_x + .5f, _y + .5f, 0);
                Vector3Int gridPos = GetComponent<Tilemap>().WorldToCell(pos);

                backgroundTileMap.SetTile(gridPos, BGTile);
            }
        }

        if (generatedMap != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3 pos = new Vector3(x + .5f, y + .5f, 0);
                    Vector3Int gridPos = GetComponent<Tilemap>().WorldToCell(pos);

                    if (generatedMap[x, y] == 1)
                    {
                        GetComponent<Tilemap>().SetTile(gridPos, tile);
                        backgroundTileMap.SetTile(gridPos, null);
                    } else
                    {                    
                        backgroundTileMap.SetTile(gridPos, BGTile);
                    }
                }
            }
        }
    }

    void SpawnEnemySpawners()
    {
        Vector3 playerPos = player.transform.position;
        EnemySpawners[0].transform.position = playerPos + new Vector3(width / 2, 0);
        EnemySpawners[1].transform.position = playerPos + new Vector3(0, height / 2);
        EnemySpawners[2].transform.position = playerPos - new Vector3(width / 2, 0);
        EnemySpawners[3].transform.position = playerPos - new Vector3(0, height / 2);
    }
}