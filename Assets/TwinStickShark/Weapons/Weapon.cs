using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {
    
    public GameObject projectile;
    public Transform projectileSpawn;

    public float shotDelay = 1;

    private bool _firing;
    
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
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation, null);
            yield return new WaitForSeconds(shotDelay);
        }

        _firing = false;
    }
    
    private void Rotate() {
        transform.LookAt(transform.position + GetDir());
    }
}
