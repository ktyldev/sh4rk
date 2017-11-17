using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FollowShot : EnemyShot {

    private Transform _target;

    private void Start() {
        _target = GameObject.FindGameObjectWithTag(GameTags.Player)
            .GetComponent<Player>()
            .Shark
            .transform;
    }

    protected override Vector3 GetMoveDir() {
        if (_target != null) {
            transform.LookAt(_target);
        }

        return transform.forward;
    }
}
