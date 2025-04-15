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

}
