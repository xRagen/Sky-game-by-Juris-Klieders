using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveForce = 10f;
    public float rotationSpeed = 100f;
    private float maxRotationAngle;
    private bool isGrounded = false;
    private Quaternion initialRotation;
    private bool isTurningBack = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxRotationAngle = 90f; // Maximum rotation to +/- 90 degrees
        initialRotation = transform.rotation; // Store the initial rotation
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Player rotation and movement
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                RotatePlayer(-1);
                MovePlayer(-1);
                isTurningBack = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                RotatePlayer(1);
                MovePlayer(1);
                isTurningBack = false;
            }
            else
            {
                isTurningBack = true;
            }
        }
    }

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        // Apply forward force for sliding down the hill only if not at the rotation limit or turning back within the limit
        if (isGrounded && (Quaternion.Angle(initialRotation, transform.rotation) < maxRotationAngle || isTurningBack))
        {
            rb.AddForce(transform.forward * moveForce, ForceMode.Force);
        }
        else
        {
            // Stop movement if at the rotation limit
            rb.velocity = Vector3.zero;
        }
    }

    // Rotate the player
    void RotatePlayer(int direction)
    {
        float currentRotationAngle = Quaternion.Angle(initialRotation, transform.rotation);
        if (currentRotationAngle >= maxRotationAngle && direction == 1)
        {
            return; // Stop rotation if the maximum rotation angle is reached and turning right
        }

        float targetAngle = initialRotation.eulerAngles.y + (direction * maxRotationAngle);
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Move the player
    void MovePlayer(int direction)
    {
        rb.AddForce(transform.right * direction * moveForce, ForceMode.Force);
    }
}
