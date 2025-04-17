// using UnityEngine;

// public class CubeOscillator : MonoBehaviour
// {
//     public float speed = 2f; // Tốc độ dao động
//     public float distance = 3f; // Biên độ di chuyển

//     private Vector3 startPos;

//     void Start()
//     {
//         startPos = transform.position; // Lưu vị trí gốc
//     }

//     void Update()
//     {
//         // Tính toán độ lệch dựa trên hàm sin
//         float offset = Mathf.Sin(Time.time * speed) * distance;
//         transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
//     }
// }
