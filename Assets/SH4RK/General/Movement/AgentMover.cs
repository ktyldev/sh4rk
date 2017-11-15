using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMover : Mover {
    
    private IAgentController _controller;

    void Start() {
        var agent = GetComponent<IAgent>();
        if (agent != null) {
            _controller = agent.controller;
        }

        if (_controller == null)
            throw new System.Exception();
    }

    protected override void Move() {
        SetDirection(_controller.moveDirection);
        base.Move();
    }
}
