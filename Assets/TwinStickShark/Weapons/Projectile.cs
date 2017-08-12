using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    
    private Mover _mover;

    void Awake() {
        _mover = GetComponent<Mover>();
    }
    
    void Start() {
        Destroy(gameObject, 5);
        _mover.SetDirection(transform.forward);
    }
    
    private void OnCollisionEnter(Collision other) {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null)
            return;

        Destroy(gameObject);
        Destroy(enemy.gameObject);
    }
}
