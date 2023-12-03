using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    protected PlayerStats player;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player = col.GetComponent<PlayerStats>();
            PickedUp();
        }
    }

    protected virtual void PickedUp()
    {
        Destroy(gameObject);
    }
}
