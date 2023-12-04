using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int m_Damage;

    [SerializeField]
    float distance;
    [SerializeField]
    float speed;

    float m_MaxTime;
    float m_Timer;
    bool m_FacingLeft = false;

    Vector3 m_MovementVector;

    private void Start()
    {
        m_MaxTime = distance / speed;
        m_Timer = m_MaxTime;
        m_MovementVector = new Vector3(speed, 0f, 0f);
    }

    private void Update()
    {
        if (Time.timeScale == 0) { return; }

        if (m_Timer > 0) 
        {
            m_Timer--; 
        }
        else
        {
            m_Timer = m_MaxTime;
            Flip();
            Debug.Log("FPLIT");
        }
        if (m_FacingLeft)
        {
            transform.position -= m_MovementVector;
        }
        else
        {
            transform.position += m_MovementVector;
        }
    }

    private void Flip()
    {
        m_FacingLeft = !m_FacingLeft;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            PlayerStats player = col.GetComponent<PlayerStats>();
            player.TakeDamage(m_Damage);
            Destroy(gameObject);
        }
    }
}

