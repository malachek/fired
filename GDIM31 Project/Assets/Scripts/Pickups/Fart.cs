using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fart : Pickup
{

    protected override void PickedUp()
    {
        TrailRenderer tr = player.GetComponent<TrailRenderer>();
        tr.material.color = new Color(.2f, .5f, .2f);
        base.PickedUp();
    }
}
