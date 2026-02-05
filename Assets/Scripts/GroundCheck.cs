using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) { isGrounded = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) { isGrounded = false; }
    }
}
