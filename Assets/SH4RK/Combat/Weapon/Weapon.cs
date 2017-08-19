using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour {

    public GameObject pewPewNoise;
    public GameObject projectile;
    public Transform[] projectileSpawns;
    public float shotDelay = 1;

    public UnityEvent onFire { get; private set; }

    private bool _firing;
    private IAgentController _controller;

    private void Awake() {
        onFire = new UnityEvent();
    }

    private void Start() {
        _controller = GetComponentInParent<IAgent>().controller;
    }

    // Update is called once per frame
    void Update() {
        if (_controller == null)
            throw new System.Exception();
        
        Rotate();

        if (_controller.attack && !_firing) {
            _firing = true;
            StartCoroutine(Fire());
        }
    }
    
    private IEnumerator Fire() {
        while (_controller.attack) {
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
        transform.LookAt(transform.position + _controller.aimDirection);
    }
}
