using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Gamepad : MonoBehaviour, IControlMode {
    public string controlMode {
        get { return "Gamepad"; }
    }

    public bool Attack() {
        return Input.GetAxis("Attack") == 1;
    }

    public Vector3 GetAimDirection() {
        return new Vector3(Input.GetAxis("RightV"), 0, Input.GetAxis("RightH"));
    }

    public Vector3 GetMoveDirection() {
        return new Vector3(Input.GetAxis("MoveH"), 0, Input.GetAxis("MoveV"));
    }

    public bool Pause() {
        return Input.GetKeyDown(KeyCode.Joystick1Button7);
    }
}
