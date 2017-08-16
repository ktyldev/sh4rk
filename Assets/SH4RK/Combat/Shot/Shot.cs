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
        Destroy(gameObject, life);    
    }
    
    void Update() {
        _mover.SetDirection(GetMoveDir());
    }

    protected virtual Vector3 GetMoveDir() {
        return transform.forward;
    }

    protected abstract bool ValidateHit(GameObject obj);
    protected abstract void OnHit(GameObject hitObject);
    
    private void OnTriggerEnter(Collider other) {
        if (!ValidateHit(other.gameObject))
            return;

        Destroy(gameObject);
        OnHit(other.gameObject);
    }
}
