using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerup : Powerup {

    public GameObject boost;

    protected override void OnPickup(Shark shark) {
        Instantiate(boost, shark.transform);
    }
}
