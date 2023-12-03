using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float dashDamage;

    float m_Health;
    public int cash; //might have to put this elsewhere
    CoinCounter coinCounter;


    void Awake()
    {
        m_Health = maxHealth;
        cash = 0;
        coinCounter = FindObjectOfType<CoinCounter>();
    }

    public bool HealthForDash()
    {
        Debug.Log(m_Health - dashDamage);
        return(m_Health - dashDamage > 0);
    }

    public void DashDamage()
    {
        TakeDamage(dashDamage);
    }

    public void TakeDamage(float damage)
    {
        m_Health -= damage;
        if (m_Health <= 0)
        {
            Debug.Log("GAME OVER");
        }
        Debug.Log(m_Health);
    }

    public void Heal(float heal)
    {
        m_Health += heal;
        if (m_Health > maxHealth)
        {
            m_Health = maxHealth;
        }
        Debug.Log(m_Health);
    }

    public void CollectCash(int amount)
    {
        cash++;
        coinCounter.SetCoinDisplay(amount);
        Debug.Log(cash);
    }

}
