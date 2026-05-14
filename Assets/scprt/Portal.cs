using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            // Lấy số sau chữ "man"
            int levelNumber = int.Parse(currentScene.Replace("man", ""));

            // Scene tiếp theo
            string nextScene = "man" + (levelNumber + 1);

            SceneManager.LoadScene(nextScene);
        }
    }
}