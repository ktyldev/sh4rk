using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerWeapon : Weapon {
    protected override bool GetIsFiring() {
        return Input.GetAxis("Attack") == 1;
    }

    protected override Vector3 GetDir() {
        return new Vector3(Input.GetAxis("RightV"), 0, Input.GetAxis("RightH"));
    }
}

