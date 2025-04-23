using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNew : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;

    private Vector2 moveInput;
    private Rigidbody rb;
    private bool isGrounded = true;

    private PlayerJumpSound jumpSoundScript;

    public Transform playerCamera; // Thêm một tham chiếu tới Camera
    public float lookSpeedX = 2f;  // Tốc độ xoay theo trục X
    public float lookSpeedY = 2f;  // Tốc độ xoay theo trục Y
    public float upperLimit = 80f;  // Giới hạn góc nhìn trên
    public float lowerLimit = 80f;  // Giới hạn góc nhìn dưới

    private float rotationX = 0f;  // Góc xoay trục X


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("Rigidbody is missing from the object.");

        jumpSoundScript = GetComponent<PlayerJumpSound>();
        if (jumpSoundScript == null)
            Debug.LogWarning("PlayerJumpSound script not found on the object.");
    }

    void Update()
    {

        animator.SetFloat("Speed", moveInput.magnitude);

        RotateCamera();

        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJump", true);
            isJumping = true;
        }
    }


    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            if (jumpSoundScript != null)
            {
                jumpSoundScript.PlayJumpSound();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);

        Vector3 flatForward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        if (flatForward.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(flatForward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 700f * Time.fixedDeltaTime); // Tốc độ quay có thể điều chỉnh
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (isJumping)
        {
            animator.SetBool("IsJump", false);
            isJumping = false;
        }
    }

    void RotateCamera()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * lookSpeedX;
        float mouseY = Mouse.current.delta.y.ReadValue() * lookSpeedY;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -upperLimit, lowerLimit);

        // Xoay camera theo trục Y (xoay trái phải)
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Xoay nhân vật theo trục Y (xoay trái phải)
        transform.Rotate(Vector3.up * mouseX);
    }

}
