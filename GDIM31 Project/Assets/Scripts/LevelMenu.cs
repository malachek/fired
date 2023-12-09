using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    [SerializeField]
    Sprite filledCashSprite;

    [SerializeField]
    Sprite emptyCashSprite;

    private void Awake()
    {

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i == 6) { return; }
            buttons[i].interactable = true;
            int cashEarned = PlayerPrefs.GetInt("Level " + (i + 1) + "Cash");
            DisplayCash(buttons[i], cashEarned);

        }
    }

    public void DisplayCash(Button button, int cashEarned)
    {
        if (button != null)
        {
            button.gameObject.SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                if (i < cashEarned) //filled in sprite
                {
                    button.transform.GetChild(i).GetComponent<Image>().GetComponent<Image>().sprite = filledCashSprite;
                }
                else                // empty sprite
                {
                    button.transform.GetChild(i).GetComponent<Image>().GetComponent<Image>().sprite = emptyCashSprite;
                }
            }
        }
    }

    public void OpenLevel(int levelId)
    {  
        GameStateManager.LoadLevel(levelId - 1);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
