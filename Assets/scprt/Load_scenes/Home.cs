using UnityEngine;

public class Home : MonoBehaviour
{
   public void HomeScene()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlayClick();
        }
        // Load the scene named "Menu" when this script starts
        UnityEngine.SceneManagement.SceneManager.LoadScene("gioi_thieu");
    }
}
