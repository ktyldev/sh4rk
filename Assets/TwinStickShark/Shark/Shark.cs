using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {

    public GameObject mount;
    
    private Vector3 _direction;
    private Mover _mover;

    void Awake() {
        _direction = new Vector3();
        _mover = GetComponent<Mover>();
    }
    
    void Start() {
        Instantiate(mount, transform);
    }
    
    void Update() {
        Move();
    }

    private void Move() {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        
        _mover.SetDirection(_direction);
    }
}
