using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyWeapon : Weapon {

    public float engagementRange;
    private Transform _target;
    
    void Start() {
        _target = Player.instance.sharkTransform;
    }
    
    protected override Vector3 GetDir() {
        return transform.forward;
    }

    protected override bool GetIsFiring() {
        return Vector3.Distance(transform.position, _target.transform.position) < engagementRange;
    }
}
