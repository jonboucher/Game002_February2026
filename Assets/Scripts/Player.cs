using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float moveDirection = 0f;
    float facing = 1f;
    [SerializeField] private float speed = 8.5f;

    private bool jumpRequested = false;

    [SerializeField] GroundCheck groundCheck;
    [SerializeField] private float jumpVelocity = 35f;

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 7.3f;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
        moveDirection = ctx.ReadValue<float>();
        
        if (moveDirection != 0)
        {
            facing = moveDirection;
        }
    }

    private void Move()
    {
        rb.linearVelocityX = moveDirection * speed;

        Vector3 playerFacing = transform.localScale;
        playerFacing.x = facing;
        transform.localScale = playerFacing;
    }

    public void HandleJump(InputAction.CallbackContext ctx) {
        if (ctx.started) { 
            jumpRequested = true;
        } 
        else if (ctx.canceled)
        {
            jumpRequested = false;
        }
    }

    private void Jump()
    {
        if (jumpRequested && groundCheck.isGrounded == true)
        {
            rb.linearVelocityY = jumpVelocity;
        }
    }

    public void handleShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            GameObject firedBulletRef = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            Bullet firedBullet = firedBulletRef.GetComponent<Bullet>();

            firedBullet.speed = firedBullet.speed * facing;

        }
    }
}
