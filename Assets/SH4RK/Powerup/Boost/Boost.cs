using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    public GameObject particles;
    public float duration;
    public float speedMultiplier;

    private Mover _mover;
    private float _originalSpeed;
    private GameObject _particles;

    void Awake() {
        _particles = Instantiate(particles, transform);

        _mover = GetComponentInParent<Mover>();
        if (_mover == null)
            throw new System.Exception();
        
        _originalSpeed = _mover.speed;
        _mover.speed *= speedMultiplier;
        Destroy(gameObject, duration);
    }

    void OnDestroy() {
        _mover.speed = _originalSpeed;
        Destroy(_particles);
    }
}
