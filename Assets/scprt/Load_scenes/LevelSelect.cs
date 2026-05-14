using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    int selectedLevel = -1;

    public void SelectLevel(int index)
    {
        // Click lần 2 -> vào màn
        if (selectedLevel == index)
        {
            LoadLevel(index);
            return;
        }

        // Click lần 1 -> chọn
        selectedLevel = index;

        UpdateButtonColors();
    }

    // void UpdateButtonColors()
    // {
    //     for (int i = 0; i < levelButtons.Length; i++)
    //     {
    //         /*
    //         Image img = levelButtons[i].GetComponent<Image>();

    //         if (i == selectedLevel)
    //             img.color = selectedColor;
    //         else
    //             img.color = normalColor;
    //         */

    //         ColorBlock colors = levelButtons[i].colors;

    //         if (i == selectedLevel)
    //         {
    //             colors.normalColor = selectedColor;
    //         }
    //         else
    //         {
    //             colors.normalColor = normalColor;
    //         }

    //         levelButtons[i].colors = colors;
    //     }
    // }


    void UpdateButtonColors()
{
    for (int i = 0; i < levelButtons.Length; i++)
    {
        if (i == selectedLevel)
        {
            levelButtons[i].transform.localScale =
                new Vector3(1.2f, 1.2f, 1.2f);
        }
        else
        {
            levelButtons[i].transform.localScale =
                Vector3.one;
        }
    }
}

    public void PlaySelectedLevel()
    {
        if (selectedLevel != -1)
        {
            LoadLevel(selectedLevel);
        }
    }

    void LoadLevel(int index)
    {
        string sceneName = "man" + (index);

        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlayClick();
        }

        SceneManager.LoadScene(sceneName);
    }
}