using UnityEngine;

public class Tower : MonoBehaviour
{
    public float FireRate = 1.0f;
    public float damage;

    private float cooldown;

    private void Start()
    {
        cooldown = FireRate;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();

        if (cooldown <= 0f && enemy)
        {
            enemy.KillEnemy();
            cooldown = FireRate;
        }
    }
}
