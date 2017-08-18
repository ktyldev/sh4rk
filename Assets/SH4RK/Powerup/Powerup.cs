using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {

    public float life = 30;
    private int _rotationSpeed = 40;

    void Start() {
        Destroy(gameObject, life);
    }

    void Update () {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
	}
    
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Shark>() == null)
            return;

        OnPickup(Player.instance.currentShark);
        Destroy(gameObject);
    }

    protected abstract void OnPickup(Shark shark);
}
