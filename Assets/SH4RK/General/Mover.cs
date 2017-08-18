using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public float rotationLerp;
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
        
        // Lerp doesn't work if the angles are opposite to each other
        var lookDirection = Mathf.Abs(transform.forward.x + _direction.x) < 0.5 && Mathf.Abs(transform.forward.z + _direction.z) < 0.5 ?
            direction :
            Vector3.Lerp(transform.forward, direction, rotationLerp == 0 ? 1 : rotationLerp);
        
        transform.LookAt(transform.position + lookDirection);
    }
}
 