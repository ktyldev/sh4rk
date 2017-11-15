using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public bool bindToGameArea;

    protected Vector3 _direction;

    void Update() {
        Move();
    }
    
    public void SetDirection(Vector3 direction) {
        _direction = direction;
        SetLookDirection(direction);
    }

    protected virtual void Move() {
        if (_direction == Vector3.zero)
            return;

        transform.Translate(_direction * Time.deltaTime * speed, Space.World);
        if (bindToGameArea) {
            transform.position = GameManager.BindToGameArea(transform.position);
        }
    }

    protected virtual void SetLookDirection(Vector3 direction) {
        transform.LookAt(transform.position + direction);
    }
}
