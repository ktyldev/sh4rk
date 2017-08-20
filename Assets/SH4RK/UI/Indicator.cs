using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Indicator : MonoBehaviour {

    public float distanceFromParent;

    public Transform target { get; set; }

    private Enemy[] _tracked;
    private Transform _parent;
    
    void Start() {
        _parent = transform.parent;
        transform.SetParent(null);
    }

    void Update() {
        if (_tracked == null)
            return;

        var closest = _tracked
            .Where(e => e != null)
            .OrderBy(e => Vector3.Distance(Player.instance.sharkTransform.position, e.transform.position))
            .FirstOrDefault();

        if (closest == null) {
            Destroy(gameObject);
            return;
        }
        
        var dir = (closest.transform.position - _parent.position).normalized;

        transform.position = _parent.position + dir * distanceFromParent;
        transform.LookAt(closest.transform);
    }
    
    public void FollowEnemies(Enemy[] enemies) {
        _tracked = enemies;
        foreach (var e in _tracked) {
            e.onDeath.AddListener(() => _tracked[Array.IndexOf(_tracked, e)] = null);
        }
    }
}
