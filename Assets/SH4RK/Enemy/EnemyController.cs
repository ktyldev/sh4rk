using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyController : IAgentController {

    private Transform _transform;
    private Transform _targetTransform;
    private int _range;

    public EnemyController(Transform thisTransform, Transform playerTransform, int engagementDistance) {
        _transform = thisTransform;
        _targetTransform = playerTransform;
        _range = engagementDistance;
    }

    public Vector3 moveDirection {
        get {
            return (_targetTransform.position - _transform.position).normalized;
        }
    }

    // TO DO: fix enemy rotation
    public Vector3 aimDirection {
        get {
            return -_transform.right;
        }
    }
    
    public bool attack {
        get {
            return Vector3.Distance(_transform.position, _targetTransform.position) < _range;
        }
    }
}
