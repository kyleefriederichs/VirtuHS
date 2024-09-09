using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 3f;  // Speed of movement
    private float jumpForce = 4f;  // Force applied when jumping
    private float rotationSpeed = 10f;  // Speed of rotation when right-clicking
    private Rigidbody rb;
    private bool isGrounded = false;

    [SerializeField] private Transform respawnPoint;

    private Vector3 rotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    void Update()
    {
        RotatePlayer();  // Handle player rotation when right-clicking
        MovePlayer();    // Handle player movement

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Apply jump force as an impulse
        }

        // Respawn the player if they fall below a certain Y position
        if (transform.position.y < -2.0f)
        {
            transform.position = respawnPoint.position;
        }
    }

    // Rotate player based on mouse movement when right-click is held down
    void RotatePlayer()
    {
        if (Input.GetMouseButton(1)) // Right mouse button held down
        {
            float mouseX = Input.GetAxis("Mouse X");  // Get horizontal mouse movement
            rotation = new Vector3(0f, mouseX * rotationSpeed, 0f);
            transform.Rotate(rotation);  // Apply rotation to the player
        }
    }

    // Move the player in the direction they are facing
    void MovePlayer()
    {
        float moveForward = Input.GetAxis("Vertical");  // Forward/backward movement
        float moveSide = Input.GetAxis("Horizontal");   // Left/right movement

        Vector3 movement = transform.forward * moveForward + transform.right * moveSide;
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);
    }

    // Detect when the player is touching something
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy")) // reset to beginning
        {
            transform.position = respawnPoint.position;
        }
    }

    // Detect when the player stays on something
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    // Detect when the player leaves a collision
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
