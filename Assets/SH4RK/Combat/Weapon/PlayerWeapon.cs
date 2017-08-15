using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerWeapon : Weapon {
    protected override bool GetIsFiring() {
        return InputManager.controlMode.Attack();
    }

    protected override Vector3 GetDir() {
        return InputManager.controlMode.GetAimDirection();
    }
}

