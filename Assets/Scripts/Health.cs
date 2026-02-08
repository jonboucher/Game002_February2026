using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 1;
    private int currentHealth = 1;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void HandleHit(int damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            HandleHit(1);
        }
    }
}
