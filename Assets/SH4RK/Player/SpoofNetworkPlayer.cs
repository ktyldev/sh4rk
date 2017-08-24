using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoofNetworkPlayer : Player {

    public GameObject networkSharkController;

    private IAgentController _sharkController;

    protected override IAgentController sharkController {
        get {
            return _sharkController;
        }
    }

    protected override void OnAwake() {
        _sharkController = Instantiate(networkSharkController).GetComponent<IAgentController>();
        base.OnAwake();
    }
}
