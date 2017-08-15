using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Gamepad : ControlMode {
    public override string controlMode {
        get { return "Gamepad"; }
    }

    public override bool Attack() {
        return Input.GetAxis("Attack") == 1;
    }

    public override Vector3 GetAimDirection() {
        return new Vector3(Input.GetAxis("RightV"), 0, Input.GetAxis("RightH"));
    }

    public override Vector3 GetMoveDirection() {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
