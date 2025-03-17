using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 spawnPoint; // Lưu vị trí xuất phát
    public float fallThreshold = -10f; // Giới hạn rơi

    void Start()
    {
        spawnPoint = transform.position; // Lưu điểm xuất phát
    }

    void Update()
    {
        // Kiểm tra nếu rơi khỏi địa hình
        if (transform.position.y < fallThreshold)
        {
            ResetPlayerPosition();
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void ResetPlayerPosition()
    {
        controller.enabled = false; // Tắt CharacterController để reset vị trí
        transform.position = spawnPoint; // Đưa player về vị trí xuất phát
        velocity = Vector3.zero; // Dừng chuyển động rơi
        controller.enabled = true; // Bật lại CharacterController
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        spawnPoint = newCheckpoint;
    }

}
