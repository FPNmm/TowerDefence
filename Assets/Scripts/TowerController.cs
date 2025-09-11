using UnityEngine;

public class Tower : MonoBehaviour
{
    public float FireRate = 1.0f;
    public float damage;

    private void OnTriggerStay(Collider other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();

        if (enemy)
        {
            enemy.KillEnemy();
        }
    }
}
