using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Pickup
{
    [SerializeField]
    int value;

    PlayerStats stats;

    GameStateManager state;
    private void Start()
    {
        stats = FindObjectOfType<PlayerStats>();
        state = FindObjectOfType<GameStateManager>();
    }
    protected override void PickedUp()
    {
        //state.CollectCash(value);
        stats.CollectCash();
        base.PickedUp();
    }
}
