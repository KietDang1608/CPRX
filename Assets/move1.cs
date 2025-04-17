using UnityEngine;

public class CubeOscillator1 : MonoBehaviour
{
    public float speed = 2f; // Tốc độ lắc
    public float distance = 3f; // Biên độ di chuyển

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Lưu vị trí ban đầu
    }

    void Update()
    {
        // Di chuyển Cube lên xuống theo trục Y (dọc)
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(startPos.x, startPos.y + offset, startPos.z);
    }
}
