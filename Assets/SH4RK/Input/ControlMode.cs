using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class ControlMode : MonoBehaviour {
    public abstract string controlMode { get; }
    public abstract Vector3 GetMoveDirection();
    public abstract Vector3 GetAimDirection();
    public abstract bool Attack();
    public abstract bool Pause();
}