using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    List<string> m_Levels = new List<string>();

    [SerializeField]
    string m_TitleSceneName;

    [SerializeField]
    string m_LevelSelectSceneName;

    [SerializeField]
    private AudioClip m_DieSound;

    [SerializeField]
    private AudioSource m_AudioSource;

    //public TextMeshProUGUI CoinDisplay = FindObjectOfType<CoinDisplay>();

    static int m_CurrentCoins;

    static GameStateManager _instance;

    enum GAMESTATE
    {
        MENU,
        LEVELSELECT,
        PLAYING,
        PAUSED,
        GAMEOVER
    }

    static GAMESTATE m_State;

    public delegate void InitLevel(int cash);
    public delegate IEnumerator GameOverDelegate();

    public static GameOverDelegate OnGameOver;
    public static InitLevel OnLevelInit;


    private void Awake()
    {
        Debug.Log("Awake method called in " + gameObject.name);
        if (_instance == null)
        {
            _instance = this;
            m_CurrentCoins = 0;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }

        

    }

    public static void NewGame()
    {
        m_State = GAMESTATE.PLAYING;
        m_CurrentCoins = 0;
        if (_instance.m_Levels.Count > 0)
        {
            SceneManager.LoadScene(_instance.m_LevelSelectSceneName);
            if (OnLevelInit != null)
            {
                OnLevelInit(m_CurrentCoins);
            }
        }
    }

    public static void LoadLevel(int levelNum)
    {
        m_State = GAMESTATE.PLAYING;

        SceneManager.LoadScene(_instance.m_Levels[levelNum]);
        
    }

    public static void OpenLevelSelect()
    {
        m_State = GAMESTATE.LEVELSELECT;

        SceneManager.LoadScene(_instance.m_LevelSelectSceneName);
       
    }

    public static void GameOver()
    {
     
        m_State = GAMESTATE.MENU;
        SceneManager.LoadScene(_instance.m_TitleSceneName);
    }

    public static void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public static void ResetScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void TogglePause()
    {
        if (m_State == GAMESTATE.PLAYING)
        {

            m_State = GAMESTATE.PAUSED;             
            Time.timeScale = 0;
            
        }
        else if (m_State == GAMESTATE.PAUSED)
        {

            m_State = GAMESTATE.PLAYING;
            Time.timeScale = 1;
                        
        }
    }

    public void CollectCash(int amount)
    {
        m_CurrentCoins++;
        //CoinDisplay.text = "$" + m_CurrentCoins;
        Debug.Log(m_CurrentCoins);
    }
}
