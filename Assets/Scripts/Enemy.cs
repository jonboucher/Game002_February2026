using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Patrol
    }

    private EnemyState enemyState = EnemyState.Patrol;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    [SerializeField] private float speed = -2.0f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        getEnemyState();
    }

    private void Idle()
    {

        rb.linearVelocityX = 0;
    }

    private void Patrol()
    {
        rb.linearVelocityX = speed;
    }

    private IEnumerator ChangeDirection()
    {
        enemyState = EnemyState.Idle;

        yield return new WaitForSeconds(1f);

        speed = speed * -1;
        sprite.flipX = !sprite.flipX;
        enemyState = EnemyState.Patrol;

        StopCoroutine(ChangeDirection());
    }

    private void getEnemyState()
    {
        switch (enemyState) { 
            case (EnemyState.Idle):
                Idle();
                break;
            case (EnemyState.Patrol):
                Patrol();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PatrolTurn")
        {
            StartCoroutine(ChangeDirection());
        }
    }
}
