using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PauseMode : ControlMode {

    private ControlMode _pausedMode;

    public override string controlMode {
        get { return _pausedMode.controlMode; }
    }

    public override bool Attack() {
        return false;
    }

    public override Vector3 GetAimDirection() {
        return Vector3.zero;
    }

    public override Vector3 GetMoveDirection() {
        return Vector3.zero;
    }

    public override bool Pause() {
        return false;
    }

    public void SetPausedMode(ControlMode mode) {
        _pausedMode = mode;
    }
}
