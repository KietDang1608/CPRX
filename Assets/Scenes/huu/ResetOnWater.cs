using UnityEngine;

public class ResetOnWater : MonoBehaviour
{
    public Transform respawnPoint; // Điểm hồi sinh
    private Rigidbody rb;
    private CharacterController controller;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        controller = GetComponent<CharacterController>(); // Kiểm tra nếu dùng CharacterController
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water")) // Nếu chạm nước
        {
            Debug.Log("Chạm nước! Quay về vị trí ban đầu: " + respawnPoint.position);

            if (controller != null)
            {
                // Nếu nhân vật dùng CharacterController
                controller.enabled = false;
                transform.position = respawnPoint.position; // Di chuyển ngay lập tức
                controller.enabled = true;
            }
            else if (rb != null)
            {
                // Nếu nhân vật dùng Rigidbody
                rb.linearVelocity = Vector3.zero; // Reset vận tốc rơi
                rb.angularVelocity = Vector3.zero;
                rb.MovePosition(respawnPoint.position);
            }
        }
    }
}
