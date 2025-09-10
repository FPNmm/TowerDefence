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
        if (spawnInterval == 0f) SpawnEnemy();
        else spawnInterval -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}
