using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Pickup
{
    [SerializeField]
    int value;
    GameStateManager state;
    private void Start()
    {
        state = FindObjectOfType<GameStateManager>();
    }
    protected override void PickedUp()
    {
        state.CollectCash(value);
        base.PickedUp();
    }
}
