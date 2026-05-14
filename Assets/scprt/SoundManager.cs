using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;

    public AudioClip jumpSound;
    public AudioClip loseSound;
    public AudioClip clickSound;
    public AudioClip poofSound;
    public AudioClip deadSound;

    private void Awake()
    {
        // chỉ giữ lại 1 SoundManager
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayLose()
    {
        audioSource.PlayOneShot(loseSound);
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayPoof()
    {
        audioSource.PlayOneShot(poofSound);
    }

    public void PlayDead()
    {
        audioSource.PlayOneShot(deadSound);
    }
}