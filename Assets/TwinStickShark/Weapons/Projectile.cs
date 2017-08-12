using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

    private Collider _collider;

    void Awake() {
        _collider = GetComponent<Collider>();
    }

    // Use this for initialization
    void Start() {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void OnCollisionEnter(Collision other) {
        var enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy == null)
            return;

        Destroy(gameObject);
        Destroy(enemy.gameObject);
    }

    private void Move() {
        var dir = transform.right;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
    }
}
