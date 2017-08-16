using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour {

    public GameObject pewPewNoise;
    public GameObject projectile;
    public Transform[] projectileSpawns;
    public float shotDelay = 1;

    public UnityEvent onFire { get; private set; }

    private bool _firing;

    private void Awake() {
        onFire = new UnityEvent();
    }

    // Update is called once per frame
    void Update() {
        Rotate();

        if (GetIsFiring() && !_firing) {
            _firing = true;
            StartCoroutine(Fire());
        }
    }

    protected abstract bool GetIsFiring();
    protected abstract Vector3 GetDir();
    
    private IEnumerator Fire() {
        while (GetIsFiring()) {
            onFire.Invoke();
            FXManager.PlaySound(pewPewNoise);

            foreach (var spawn in projectileSpawns) {
                Instantiate(projectile, spawn.position, spawn.rotation, null);
            }
            yield return new WaitForSeconds(shotDelay);
        }

        _firing = false;
    }
    
    private void Rotate() {
        transform.LookAt(transform.position + GetDir());
    }
}
