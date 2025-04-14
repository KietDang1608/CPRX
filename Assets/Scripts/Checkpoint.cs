using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu là Player
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint đã được lưu: " + transform.position);
            }
        }
    }
}
