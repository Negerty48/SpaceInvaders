using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float maxSpawnRateInSeconds = 5f;

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
        maxSpawnRateInSeconds = 5f;
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

    public void StartEnemySpawner()
    {
        Invoke(nameof(SpawnEnemy), maxSpawnRateInSeconds);
        InvokeRepeating(nameof(IncreaseSpawnRate), 0f, 30f);
    }

    public void StopEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}