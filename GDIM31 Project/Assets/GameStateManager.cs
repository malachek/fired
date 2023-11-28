/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    //  for our second lvl
    [SerializeField]
    private List<string> m_levels = new List<string>();

    [SerializeField]
    private string m_TitleSceneName;

    private static GameStateManager _instance;

    enum GAMESTATE
    {
        MENU,
        PLAYING,
        QUIT
 
    }

    private static GAMESTATE m_State;

    public static void Start()
    {
        m_State = GAMESTATE.PLAYING;
        
    }
}
*/


// this is for later when we have levels and lives.
// ill add a pause as well (using Salmon's video)
// i have a simple title menu manager set up for alpha test but
// later ill finish the game state