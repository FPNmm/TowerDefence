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

        int singleDidgit = 1;
        int singleDidgit2 = 0;
        while(singleDidgit2+singleDidgit < 10)
        {
            singleDidgit2=singleDidgit2+singleDidgit;
            if (singleDidgit2 <= 10)
            {
                Debug.Log(singleDidgit2);
            }
        }

        int numberOfEnemiesSpawned = 0;
        while (numberOfEnemiesSpawned < waveSize)
        {
            SpawnEnemy();
            numberOfEnemiesSpawned++;
        }

        for(int numOfEnemiesSpawned = 0; numOfEnemiesSpawned < waveSize; numOfEnemiesSpawned++)
        {
            SpawnEnemy();
        }
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

    private int AddNumbers(int num1, int num2)
    {
        return num1 + num2;
    }
}
