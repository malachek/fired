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
    private Sprite filledCashSprite;

    [SerializeField]
    private Sprite emptyCashSprite;


    private void Awake()
    {

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            //if (buttons[i] != null)
            //{
            //    buttons[i].gameObject.SetActive(false);
            //}
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i == 6) { return; }
            buttons[i].interactable = true;

            int cashEarned = PlayerPrefs.GetInt("Level " + (i + 1) + "Cash");
            //the int amount of cash is PlayerPrefs.GetInt("Level " + (i + 1) + "Cash")

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
                if (i < cashEarned)
                {
                    //filled in sprite
                    button.transform.GetChild(i).GetComponent<Image>().GetComponent<Image>().sprite = filledCashSprite;
                    
                    //.sprite
                    //    = Resources.Load<Sprite>("cash_filled");
                }
                else
                {
                    // empty sprite
                    button.transform.GetChild(i).GetComponent<Image>().GetComponent<Image>().sprite = emptyCashSprite;
                }
            }
        }
    }

    //private void Awake()
    //{
    //    int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

    //    for (int i = 0; i < buttons.Length; i++)
    //    {
    //        buttons[i].interactable = false;
    //        // Assuming you have star sprites assigned in the inspector
    //        cashDisplays[i].sprite = emptyCashSprite;
    //    }

    //    for (int i = 0; i < unlockedLevel; i++)
    //    {
    //        if (i == 6) { return; }
    //        buttons[i].interactable = true;

    //        // Replace this logic with your actual cash-based condition
    //        if (PlayerPrefs.GetInt("Level " + (i + 1) + "Cash") >= 1)
    //        {
    //            cashDisplays[i].sprite = filledCashSprite;
    //        }
    //    }
    //}

    public void OpenLevel(int levelId)
    {  
        GameStateManager.LoadLevel(levelId - 1);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
