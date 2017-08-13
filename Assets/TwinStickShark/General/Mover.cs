using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public bool bindToGameArea;

    private Vector3 _direction;
    
	void Update () {
        if (_direction == null || _direction == Vector3.zero)
            return;
        
        transform.Translate(_direction * Time.deltaTime * speed, Space.World);
        if (bindToGameArea) {
            transform.position = GameManager.BindToGameArea(transform.position);
        }
	}

    public void SetDirection(Vector3 direction) {
        _direction.x = direction.x;
        _direction.z = direction.z;

        transform.LookAt(transform.position + _direction);
    }
}
 