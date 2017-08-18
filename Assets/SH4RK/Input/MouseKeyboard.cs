using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MouseKeyboard : ControlMode {
    public override string controlMode {
        get { return "Mouse & Keyboard"; }
    }

    public override bool Attack() {
        return Input.GetMouseButton(0);
    }

    public override Vector3 GetAimDirection() {
        var mousePos = Input.mousePosition;

        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;

        return new Vector3(-mousePos.y, 0, mousePos.x).normalized;
    }

    public override Vector3 GetMoveDirection() {
        var move = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) {
            move.x--;
        }
        if (Input.GetKey(KeyCode.D)) {
            move.x++;
        }
        if (Input.GetKey(KeyCode.W)) {
            move.z++;
        }
        if (Input.GetKey(KeyCode.S)) {
            move.z--;
        }

        return move.normalized;
    }
}
