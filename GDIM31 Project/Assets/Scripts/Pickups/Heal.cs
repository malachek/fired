using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Pickup
{
    protected override void PickedUp()
    {
        player.Heal();
        base.PickedUp();
    }
}
