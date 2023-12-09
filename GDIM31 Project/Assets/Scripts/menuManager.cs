using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    PauseMenu pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu != null)
            {
                pauseMenu.TogglePauseMenu();  
            }
        }
    }
}
