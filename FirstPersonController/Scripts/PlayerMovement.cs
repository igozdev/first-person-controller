using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    public float speed = 10;
    public float gravity = -10;
    public float jump = 1;

    private Vector3 velocity;

    [SerializeField] private Transform groundSphere;
    [SerializeField] private LayerMask groundLayer;

    public float groundDistance = 0.1f;
    private bool isGrounded;

    void Update()
    {
        // Check if player is grounded by casting a sphere around the groundCheck transform position
        isGrounded = Physics.CheckSphere(groundSphere.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
            // Slightly negative velocity while grounded so that the player stays on the ground and not floating slightly above
            velocity.y = -2;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jump * -2 * gravity); /* # !!!!! possible optimization for this function by not using sqrt !!!!! # */

        // Add gravity to vertical velocity
        velocity.y += gravity * Time.deltaTime;

        // This is a combination of the 2 functions "controller.Move(speed * Time.deltaTime * move);" and "controller.Move(velocity * Time.deltaTime);"
        // to avoid repeated usage of the move function
        // Note: "speed * Time.deltaTime * move" is better than move* speed * Time.deltaTime since FxFxV is faster (2x+) than FxVxF or VxFxF
        controller.Move((speed * Time.deltaTime * move) + (velocity * Time.deltaTime));
    }
}