using UnityEngine;

public class Load_menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {         if (SoundManager.instance != null)
        {
        SoundManager.instance.PlayClick();
        }
        // Load the scene named "Menu" when this script starts
        UnityEngine.SceneManagement.SceneManager.LoadScene("man_choi");
    }


    
}
