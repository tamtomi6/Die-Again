using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string currentLevel;

    public static int IQ = 0;

    private static GameManager instance;

    private void Awake()
    {
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
}