using System.Collections;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Konfigurace generace")]    
    public int initialObjects = 200; // Number of objects to spawn at the start
    public int objectsPerFrame = 5; // Number of objects to spawn per frame as the player moves
    public float continuousSpawnRadius = 25f; // Radius around the player for continuous spawning
    public float initialSpawnAreaSize = 20f; // Side length of the square area for initial object spawning
    public float minDistanceBetweenObjectsX = 8f; // Minimum distance between spawned objects along the X-axis
    public float minDistanceBetweenObjectsY = 16f; // Minimum distance between spawned objects along the Y-axis

    [Header("Reference")]
    public GameObject[] objectPrefabs; // Prefabs of the objects you want to spawn
    //public LakeSpawner LakeSpawnerScript;
    public FishingEvent FishingEventScript;
    public GameObject PlayerObject;
    private Transform player;

    public static MapGenerator Instance { get; private set; }

    void Start()
    {
        Instance = this;

        PlayerObject = GameManager.Instance.Player;

        //LakeSpawnerScript = LakeSpawner.Instance;

        player = PlayerObject.transform;

        // Spawn initial objects
        Vector2 initialSpawnCenter = player.position;
        for (int i = 0; i < initialObjects; i++)
        {
            Vector2 randomPosition = GetRandomPositionInSquare(initialSpawnCenter, initialSpawnAreaSize);
            SpawnObject(randomPosition);
        }

        // Start spawning more objects as the player moves
        StartCoroutine(ContinuousObjectSpawn());
    }

    IEnumerator ContinuousObjectSpawn()
    {
        while (true)
        {
            // Spawn objectsPerFrame objects each frame
            for (int i = 0; i < objectsPerFrame; i++)
            {
                Vector2 randomPosition = GetRandomPositionAroundPlayer(continuousSpawnRadius);
                SpawnObject(randomPosition);
            }

            // Wait for the next frame
            yield return null;
        }
    }

    Vector2 GetRandomPositionAroundPlayer(float radius)
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 randomPosition = (Vector2)player.position + randomDirection * Random.Range(radius / 2f, radius);

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

    public void SpawnObject(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, new Vector2(minDistanceBetweenObjectsX, minDistanceBetweenObjectsY), 0f);

        if (colliders.Length == 0)
        {
            GameObject randomObjectPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            if (randomObjectPrefab.name.StartsWith("Voda")) //puvodne se reference pridavaly tady, ale vzhledem k udalostem se to da zjednodusit tim ze se pridaji automaticky na startu FishingEvent scriptu
            {
                GameObject newObject = Instantiate(randomObjectPrefab, position, Quaternion.identity);
                
                FishingEvent lakeScript = newObject.GetComponent<FishingEvent>();
                
                // Set references for the lake fishing mini-game
                //    lakeScript.FishingMiniGameCanvas = LakeSpawnerScript.fishingMiniGameCanvas;
                //Debug.Log("given fishingminigamcanvas reference");
                //    lakeScript.InteractWindow = LakeSpawnerScript.InteractWindow;
                //Debug.Log("given interactwindow reference");
                //    lakeScript.FishingMiniGameScript = LakeSpawnerScript.fishingMiniGameScript;
                //    lakeScript.TimerScript = LakeSpawnerScript.timerScript;
                //    lakeScript.RybaSpriteRenderer = LakeSpawnerScript.rybaSpriteRenderer;
                //lakeScript.RybaWindow = LakeSpawnerScript.rybaWindowPrefab;  //neni to nikde potreba je to k nice mu ale necham to tady pro budouci potreby (asi nebudou)
                //objekty se nebudou spawnovat pokudse nevyplni vsechny tyhle reference -> jestli s tim nekdy bude problem je to kvuli tomu

            }
            else //GameObjecty, které nejsou "Voda..." se vygenerujou bez scriptu
            {
                Instantiate(randomObjectPrefab, position, Quaternion.identity);
            }
        }
    }
}