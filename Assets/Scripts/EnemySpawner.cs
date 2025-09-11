using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int waveSize;
    public float spawnInterval;
    public GameObject enemyPrefab;

    private float spawnTime;

    private void Start()
    {
        spawnTime = spawnInterval;
    }

    private void Update()
    {
        if (spawnTime <= 0f) SpawnEnemy();
        else spawnTime -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
        spawnTime = spawnInterval;
    }
}
