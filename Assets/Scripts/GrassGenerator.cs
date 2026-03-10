using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    public GameObject[] grassPrefabs;
    public int initialGrass = 100;
    public float initialSpawnAreaSize = 50f;
    public float minDistanceBetweenGrass = 3f;
    public float continuousSpawnRadius = 50f;

    public GameObject PlayerObject;

    private Transform player;
    private List<Vector2> grassPositions = new List<Vector2>();

    void Start()
    {
        player = PlayerObject.transform;

        // Spawn initial grass objects
        Vector2 initialSpawnCenter = player.position;
        for (int i = 0; i < initialGrass; i++)
        {
            Vector2 randomPosition = GetRandomPositionInSquare(initialSpawnCenter, initialSpawnAreaSize);
            SpawnGrass(randomPosition);
        }

        // Start spawning more grass objects as the player moves
        StartCoroutine(ContinuousGrassSpawn());
    }

    IEnumerator ContinuousGrassSpawn()
    {
        while (true)
        {
            // Spawn objectsPerFrame objects each frame
            for (int i = 0; i < initialGrass / 10; i++) // Adjust the divisor as needed
            {
                Vector2 randomPosition = GetRandomPositionAroundPlayer();
                SpawnGrass(randomPosition);
            }

            // Wait for the next frame
            yield return null;
        }
    }

    Vector2 GetRandomPositionAroundPlayer()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 randomPosition = (Vector2)player.position + randomDirection * Random.Range(minDistanceBetweenGrass / 2f, continuousSpawnRadius);

        return randomPosition;
    }

    Vector2 GetRandomPositionInSquare(Vector2 center, float sideLength)
    {
        float halfSide = sideLength / 2f;
        Vector2 randomPosition = new Vector2(
            Random.Range(center.x - halfSide, center.x + halfSide),
            Random.Range(center.y - halfSide, center.y + halfSide)
        );

        return randomPosition;
    }

    void SpawnGrass(Vector2 position)
    {
        // Check if the new grass position is too close to existing grass
        bool canSpawn = true;
        foreach (Vector2 grassPos in grassPositions)
        {
            if (Vector2.Distance(position, grassPos) < minDistanceBetweenGrass)
            {
                canSpawn = false;
                break;
            }
        }

        // If the position is valid, spawn the grass
        if (canSpawn)
        {
            grassPositions.Add(position);
            GameObject randomGrassPrefab = grassPrefabs[Random.Range(0, grassPrefabs.Length)];
            Instantiate(randomGrassPrefab, position, Quaternion.identity);
        }
    }
}