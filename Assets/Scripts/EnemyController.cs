using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed;

    private Vector3 moveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
    }

    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
