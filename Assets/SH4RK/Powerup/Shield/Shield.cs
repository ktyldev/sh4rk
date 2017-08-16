using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private Transform _target;
    public int rotationSpeed = 40;

	void Update () {
        transform.position = _target.position;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    
    public void SetTarget(Shark shark) {
        _target = shark.transform;
        shark.SetShield(this);
    }
}
