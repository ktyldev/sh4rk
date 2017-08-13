using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Shot : MonoBehaviour {

    public float life;

    private Mover _mover;

    void Awake() {
        _mover = GetComponent<Mover>();
    }

    void Start() {
        Destroy(gameObject, life);    
        _mover.SetDirection(transform.forward);
    }

    protected abstract bool ValidateHit(GameObject obj);
    protected abstract void OnHit(GameObject hitObject);

    private void OnTriggerEnter(Collider other) {
        if (!ValidateHit(other.gameObject))
            return;

        Destroy(gameObject);
        OnHit(other.gameObject);
    }

    //private void OnCollisionEnter(Collision other) {
    //    //var enemy = other.gameObject.GetComponent<Enemy>();
    //    //if (enemy == null)
    //    //    return;
    //    if (!ValidateHit(other.gameObject))
    //        return;
        
    //    Destroy(gameObject);
    //    OnHit(other.gameObject);
    //}
}
