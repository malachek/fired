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

    int m_MaxCash;
    int m_CurrentCash = 0;
    int m_HealthBarIndex;


    void Awake()
    {
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

    public bool HealthForDash()
    {
        bool willLive = m_HealthBarIndex > 0;
        if (!willLive)
        {
            StartCoroutine(LevelTextDisplay("Low HP, Can Not Dash"));
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

}
