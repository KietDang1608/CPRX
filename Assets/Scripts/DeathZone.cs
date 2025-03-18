using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu là Player
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ResetPlayerPosition(); // Gọi hàm reset vị trí về checkpoint
                Debug.Log("Người chơi đã chạm vào vật thể nguy hiểm! Quay lại checkpoint.");
            }
        }
    }
}
