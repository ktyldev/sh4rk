using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerup : Powerup {

    public GameObject weapon;

    protected override void OnPickup(Shark shark) {
        shark.PowerupWeapon(weapon);
    }
}
