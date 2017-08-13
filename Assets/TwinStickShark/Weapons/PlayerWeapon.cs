using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerWeapon : Weapon {
    protected override bool GetIsFiring() {
        return InputManager.Attack();
    }

    protected override Vector3 GetDir() {
        return InputManager.GetAimDirection();
    }
}

