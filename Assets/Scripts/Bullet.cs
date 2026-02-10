using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 20f;

    [HideInInspector] public Gun firedFrom;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
       rb.linearVelocity = new Vector3(speed, 0 , 0);                                        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            Destroy(gameObject);
            firedFrom.onScreenBullets--;
        }
    }
}
