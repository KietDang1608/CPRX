using UnityEngine;

public class PlayerJumpSound : MonoBehaviour
{
    public AudioClip jumpSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}
