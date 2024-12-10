using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Player movement speed
    private Rigidbody2D rb; // Rigidbody2D component for physics-based movement

    private Vector2 moveDirection; // Direction the player is moving in

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Get input from the player (arrow keys or WASD)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Normalize input so the player moves at a consistent speed
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Apply the movement using Rigidbody2D, taking moveSpeed into account
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an uncleared tile (i.e., it has an active collider)
        if (collision.collider.CompareTag("UnclearedTile"))
        {
            // Prevent movement if colliding with an uncleared tile
            moveDirection = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Allow movement again when the player is no longer colliding with a tile
        if (collision.collider.CompareTag("UnclearedTile"))
        {
            moveDirection = moveDirection.normalized; // Restore the previous movement direction
        }
    }
}