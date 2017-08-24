using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SpoofInput : MonoBehaviour, IAgentController {
    public Vector3 moveDirection {
        get {
            return Vector3.forward;
        }
    }

    public Vector3 aimDirection { get { return Vector3.right; } }

    public bool attack { get { return true; } }
}
