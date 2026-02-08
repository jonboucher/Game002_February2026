using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Vector3 initialPosition;
    float moveDirection = 0f;
    float facing = 1f;
    [SerializeField] private float speed = 8.5f;

    private bool jumpRequested = false;

    [SerializeField] GroundCheck groundCheck;
    [SerializeField] private float jumpVelocity = 35f;

    [SerializeField] private Gun gun;
    [SerializeField] private GameObject bullet;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 7.3f;
        initialPosition = transform.position;
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

    public void HandleShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            gun.Shoot(facing);
        }
    }

    private void Respawn()
    {
        transform.position = initialPosition;
        rb.linearVelocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            Respawn();
        }
    }
}
