using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerup : Powerup {

    public GameObject weapon;
    public int shots;

    protected override void OnPickup(Shark shark) {
        shark.PowerupWeapon(weapon, shots);
    }
}
