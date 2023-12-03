using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Pickup
{
    [SerializeField]
    int value;
    protected override void PickedUp()
    {
        player.CollectCash(value);
        base.PickedUp();
    }
}
