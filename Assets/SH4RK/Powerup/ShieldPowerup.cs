using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ShieldPowerup : Powerup {

    public GameObject shield;

    protected override void OnPickup(Shark shark) {
        var newShield = Instantiate(shield).GetComponent<Shield>();
        newShield.SetTarget(shark.transform);
    }
}
