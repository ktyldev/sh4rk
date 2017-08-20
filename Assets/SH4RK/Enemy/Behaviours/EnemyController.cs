using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyController : MonoBehaviour, IAgentController {
    
    private Transform _targetTransform;

    public int engagementDistance;

    void Start() {
        _targetTransform = Player.instance.sharkTransform;
    }

    public Vector3 moveDirection {
        get {
            return _targetTransform == null ? Vector3.zero : (_targetTransform.position - transform.position).normalized;
        }
    }

    // TO DO: fix enemy rotation
    public Vector3 aimDirection {
        get {
            return -transform.right;
        }
    }
    
    public bool attack {
        get {
            return GetAttack();
        }
    }

    protected virtual bool GetAttack() {
        return _targetTransform == null ? 
            false : 
            Vector3.Distance(transform.position, _targetTransform.position) < engagementDistance;
    }
}
