using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {
    
    public GameObject mount;
    
    private Mover _mover;

    void Awake() {
        _mover = GetComponent<Mover>();
    }
    
    void Start() {
        Instantiate(mount, transform);
    }
    
    void Update() {
        Move();
    }

    private void Move() {
        _mover.SetDirection(InputManager.GetMoveDirection());
    }
}
