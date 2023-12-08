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
    TextMeshProUGUI[] cashDisplays;

    private void Awake()
    {
        
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            cashDisplays[i].text = "";
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i == 6) { return; }
            buttons[i].interactable = true;
            string cashText = "$" + PlayerPrefs.GetInt("Level " + (i + 1) + "Cash") + "/3";
            cashDisplays[i].text = cashText;
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
