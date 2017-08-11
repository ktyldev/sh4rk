using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {

    public GameObject mount;

    public float speed;
    
    private Vector3 _direction;

    // Use this for initialization
    void Start() {
        Instantiate(mount, transform);
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        _direction = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")).normalized;

        if (_direction == Vector3.zero)
            return;

        transform.LookAt(transform.position + _direction);

        var moveDir = new Vector3(_direction.z, 0, -_direction.x);
        transform.Translate(moveDir * Time.deltaTime * speed, Space.World);
    }
}
