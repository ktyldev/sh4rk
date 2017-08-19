using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IAgentController {
    Vector3 moveDirection { get; }
    Vector3 aimDirection { get; }
    bool attack { get; }
}
