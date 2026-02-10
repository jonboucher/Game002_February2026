using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 1;
    public int currentHealth = 1;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && gameObject.tag == "Player")
        {
            HandleHit(1);
        }
    }
}
