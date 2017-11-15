using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : AgentMover {

    public float rotationLerp;
    
    protected override void SetLookDirection(Vector3 direction) {
        // Lerp doesn't work if the angles are opposite to each other
        var lookDirection = Mathf.Abs(transform.forward.x + _direction.x) < 0.5 && Mathf.Abs(transform.forward.z + _direction.z) < 0.5 ?
            direction :
            Vector3.Lerp(transform.forward, direction, rotationLerp == 0 ? 1 : rotationLerp);

        base.SetLookDirection(lookDirection);
    }
}
