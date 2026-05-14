using UnityEngine;

public class Back : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Back_0()
    {
        SoundManager.instance.PlayClick();
        // Load the scene named "gioi_thieu" when this script starts
        UnityEngine.SceneManagement.SceneManager.LoadScene("gioi_thieu");
    }
}
