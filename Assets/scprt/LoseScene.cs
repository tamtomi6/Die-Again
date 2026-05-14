using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseScene : MonoBehaviour
{
    public TextMeshProUGUI iqText;
    public TextMeshProUGUI levelText;

    void Start()
    {
        iqText.text =  GameManager.IQ + " IQ";

        levelText.text = GameManager.currentLevel.Replace("man", "Level ");
    }

    public void Retry()
    {
        SceneManager.LoadScene(GameManager.currentLevel);
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}