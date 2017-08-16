using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ShieldPowerup : Powerup {

    public GameObject shield;

    protected override void OnPickup(Shark shark) {
        if (shark.isShielded) {
            Destroy(gameObject);
            return;
        }
        
        Instantiate(shield)
            .GetComponent<Shield>()
            .SetTarget(shark);
    }
}
