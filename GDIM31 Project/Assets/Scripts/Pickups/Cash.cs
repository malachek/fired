using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Pickup
{
    PlayerStats stats;

    GameStateManager state;
    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        state = FindObjectOfType<GameStateManager>();
    }
    protected override void PickedUp()
    {
        state.CollectCash();
        stats.CollectCash();
        base.PickedUp();
    }
}
