using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float dashDamage;

    float health;


    void Awake()
    {
        health = maxHealth;
    }

    public bool HealthForDash()
    {
        Debug.Log(health - dashDamage);
        return(health - dashDamage > 0);
    }

    public void DashDamage()
    {
        TakeDamage(dashDamage);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
    

}
