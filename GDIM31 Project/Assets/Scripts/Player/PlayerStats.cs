using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    Image[] healthPoints;
    
    [SerializeField]
    TextMeshProUGUI textElement;

    [SerializeField]
    TextMeshProUGUI textCashCount;

    [SerializeField]
    TextMeshProUGUI textTime;

    public float stopWatch;

    public int m_MaxCash;
    public int m_CurrentCash = 0;
    int m_HealthBarIndex;


    void Awake()
    {
        stopWatch = 0f;
        textElement.text = null;
        m_HealthBarIndex = 3;
        foreach (Image healthPoint in healthPoints) 
        {
            healthPoint.enabled = true;
        }
        var totalCash = Object.FindObjectsOfType<Cash>();
        m_MaxCash = totalCash.Length;
        textCashCount.text = $"${m_CurrentCash}/{m_MaxCash}";
    }

    private void FixedUpdate()
    {
        stopWatch += Time.fixedDeltaTime;
    }

    private void Update()
    {
        int minutes = (int)stopWatch/60;
        if (minutes > 59)
        {
            StartCoroutine(LevelTextDisplay("How did this take you an hour and you still aren't finished..."));
            GameStateManager.GameOver();
        }
        int seconds = (int)stopWatch % 60;
        int milliseconds = (int)(stopWatch % 1 * 60);
        textTime.text = minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }

    

    public bool HealthForDash()
    {
        bool willLive = m_HealthBarIndex > 0;
        if (!willLive)
        {
            StartCoroutine(LevelTextDisplay("Low HP, Can Not Dash. Press esc to open Pause Menu"));
        }
        return (willLive);
    }

    public void TakeDamage()
    {
        healthPoints[m_HealthBarIndex].enabled = false;
        m_HealthBarIndex--;
        if (m_HealthBarIndex < 0)
        {
            StartCoroutine(LevelTextDisplay("GAME OVER"));
            GameStateManager.GameOver();
        }
    }

    public void Heal()
    {
        if (m_HealthBarIndex < 3)
        {
            m_HealthBarIndex++;
            healthPoints[m_HealthBarIndex].enabled = true;
        }
    }

    public void CollectCash()
    {
        m_CurrentCash++;
        textCashCount.text = $"${m_CurrentCash}/{m_MaxCash}";
    }

    IEnumerator LevelTextDisplay(string text)
    {
        Debug.Log(text);
        textElement.text = text;
        yield return new WaitForSeconds(1.5f);
        textElement.text = null;
    }

    public string GetTime()
    {
        int minutes = (int)stopWatch / 60;
        int seconds = (int)stopWatch % 60;
        int milliseconds = (int)(stopWatch % 1 * 60);
        return (minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2"));
    }

}
