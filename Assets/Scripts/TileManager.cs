using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 4;
    private Queue<GameObject> activeTiles = new Queue<GameObject>();
    public Transform playerTransform;
    public float deleteDistance = 30;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefab.Length));
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z - tileLength > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefab.Length));
            ReuseTile();
            DeleteOldTiles();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefab[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Enqueue(go);
        zSpawn += tileLength;
    }

    private void ReuseTile()
    {
        GameObject reusedTile = activeTiles.Dequeue();
        reusedTile.transform.position = transform.forward * zSpawn;
        activeTiles.Enqueue(reusedTile);
        zSpawn += tileLength;
    }
    void DeleteOldTiles()
    {
        while (activeTiles.Count > 0)
        {
            GameObject tile = activeTiles.Peek();
            if (playerTransform.position.z - tile.transform.position.z > deleteDistance)
            {
                Destroy(activeTiles.Dequeue());
            }
            else
            {
                break;
            }
        }
    }

}
