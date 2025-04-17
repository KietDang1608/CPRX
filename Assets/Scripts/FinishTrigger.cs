using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chạm điểm thắng!");

            // Lấy thời gian từ timer
            float timePlayed = FindObjectOfType<GameTimer>().StopTimer();
            float bestTime = PlayerPrefs.GetFloat("BestTimeOverall", float.MaxValue);

            Debug.Log("Thời gian hoàn thành: " + timePlayed.ToString("F2") + " giây");

            // Lưu lại để hiện ở Main Menu
            if (timePlayed < bestTime)
            {
                PlayerPrefs.SetFloat("BestTimeOverall", timePlayed);
                PlayerPrefs.Save();
            }

            // Chuyển cảnh về menu, hoặc hiện UI thắng
            SceneManager.LoadScene("MainMenu"); // hoặc hiện popup trước rồi load
        }
    }
}
