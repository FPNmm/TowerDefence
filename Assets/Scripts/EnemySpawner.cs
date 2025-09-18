using Assets.Scripts;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public TowerBuildingController towerBuildingController;
    public int waveSize;
    public float spawnInterval;
    public GameObject enemyPrefab;

    private float spawnTime;
    private bool isInBuildingPhase = true;
    private int amountOfEnemiesSpawned;

    private void Start()
    {
        spawnTime = spawnInterval;
    }

    private void Update()
    {
        switch (isInBuildingPhase)
        {
            case true:
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        towerBuildingController.EnterEnemyPhase();
                        isInBuildingPhase = false;
                    }
                    break;
                }
            case false:
                {
                    if (amountOfEnemiesSpawned >= waveSize)
                    {
                        isInBuildingPhase = true;
                        amountOfEnemiesSpawned = 0;
                        towerBuildingController.EnterBuildingPhase();
                    }

                    if (spawnTime <= 0f) SpawnEnemy();
                    else spawnTime -= Time.deltaTime;
                    break;
                }
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
        spawnTime = spawnInterval;
        amountOfEnemiesSpawned++;
    }
}
