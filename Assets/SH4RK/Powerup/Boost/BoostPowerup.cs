using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerup : Powerup {

    public GameObject boost;

    protected override void OnPickup(Shark shark) {
        if (shark.GetComponentInChildren<Boost>()) {
            Destroy(gameObject);
            return;
        }

        Instantiate(boost, shark.transform);
    }
}
