using UnityEngine;

public class DeadzoneController : MonoBehaviour
{
    public int health;

    private int currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.GetComponent<EnemyController>())
       {
            currentHealth -= 1;
            Destroy(other.gameObject);

            if (currentHealth == 0) Debug.Log("You Lose!");
       }
    }
}
