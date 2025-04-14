using UnityEngine;
using UnityEngine.UI;
using TMPro; // Nếu bạn dùng TextMeshPro

public class GuessingGame : MonoBehaviour
{
    public TMP_InputField guessInputField; // Kéo Input Field (TMP) vào đây từ Inspector
    int randomNumber;
    int attemptsLeft = 5;

    void Start()
    {
        randomNumber = UnityEngine.Random.Range(1, 101);
        Debug.Log("Số bí mật đã được tạo. Bạn có " + attemptsLeft + " lần đoán.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (guessInputField != null && !string.IsNullOrEmpty(guessInputField.text))
            {
                if (int.TryParse(guessInputField.text, out int guess))
                {
                    attemptsLeft--;

                    if (guess == randomNumber)
                    {
                        Debug.Log("Chúc mừng! Bạn đã đoán đúng số " + randomNumber + ".");
                        enabled = false;
                    }
                    else if (guess < randomNumber)
                    {
                        Debug.Log("Số bạn đoán quá thấp. Bạn còn " + attemptsLeft + " lần đoán.");
                    }
                    else if (guess > randomNumber)
                    {
                        Debug.Log("Số bạn đoán quá cao. Bạn còn " + attemptsLeft + " lần đoán.");
                    }
                }
                else
                {
                    Debug.LogWarning("Vui lòng nhập một số nguyên hợp lệ.");
                }

                if (attemptsLeft <= 0 && guess != randomNumber)
                {
                    Debug.Log("Hết lượt đoán! Số bí mật là: " + randomNumber);
                    enabled = false;
                }
            }
            else
            {
                Debug.LogWarning("Vui lòng nhập một số vào ô Input Field.");
            }
        }
    }
}