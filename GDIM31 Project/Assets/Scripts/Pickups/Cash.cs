using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Pickup
{
    PlayerStats stats;

    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
    }
    protected override void PickedUp()
    {
        stats.CollectCash();
        base.PickedUp();
    }
}
