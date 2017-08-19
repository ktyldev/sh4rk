using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MouseKeyboard : ControlMode {
    
    private Plane _hitPlane;

    void Start() {
        _hitPlane = new Plane(Vector3.up, Vector3.zero);
    }
    
    public override string controlMode {
        get { return "Mouse & Keyboard"; }
    }

    public override bool Attack() {
        return Input.GetMouseButton(0);
    }

    public override Vector3 GetAimDirection() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        Vector3 aimPos;
        if (_hitPlane.Raycast(ray, out distance)) {
            aimPos = ray.GetPoint(distance);
        } else {
            return Vector3.zero;
        }

        var dir = aimPos - Player.instance.sharkTransform.position;

        return  new Vector3(-dir.z, 0, dir.x).normalized;
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
