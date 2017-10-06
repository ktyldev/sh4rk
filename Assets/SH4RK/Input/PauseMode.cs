using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PauseMode : MonoBehaviour, IControlMode {

    private IControlMode _pausedMode;

    public string controlMode {
        get { return _pausedMode.controlMode; }
    }

    public bool Attack() {
        return false;
    }

    public bool Continue() {
        return _pausedMode.Continue();
    }

    public Vector3 GetAimDirection() {
        return Vector3.zero;
    }

    public Vector3 GetMoveDirection() {
        return Vector3.zero;
    }

    public bool Pause() {
        return false;
    }

    public void SetPausedMode(IControlMode mode) {
        _pausedMode = mode;
    }
}
