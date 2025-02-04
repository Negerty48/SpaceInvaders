using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float maxSpawnRateInSeconds = 5f;

    void Start()
    {
        Invoke(nameof(SpawnEnemy), maxSpawnRateInSeconds); // Primer enemigo después de `maxSpawnRateInSeconds`
        InvokeRepeating(nameof(IncreaseSpawnRate), 0f, 30f); // Reduce el tiempo de spawn cada 30s
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);

        Vector2 spawnPosition = new Vector2(Random.Range(min.x, max.x), max.y);
        Instantiate(Enemy, spawnPosition, Quaternion.identity);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn() 
    {
        float spawnInNSeconds = Mathf.Max(1f, Random.Range(1f, maxSpawnRateInSeconds));
        Invoke(nameof(SpawnEnemy), spawnInNSeconds);
    }

    void IncreaseSpawnRate() 
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        else
        {
            CancelInvoke(nameof(IncreaseSpawnRate));
        }
    }
}