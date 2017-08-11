using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float shotDelay = 1;

    private bool _firing;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Rotate();

        if (FireButtonPressed() && !_firing) {
            _firing = true;
            StartCoroutine(Fire());
        }
    }

    private bool FireButtonPressed() {
        return Input.GetAxis("Attack") == 1;
    }

    private IEnumerator Fire() {
        while (FireButtonPressed()) {
            Debug.Log("Fire!");
            yield return new WaitForSeconds(shotDelay);
        }

        _firing = false;
    }

    private void Rotate() {
        var dir = new Vector3(Input.GetAxis("RightV"), 0, Input.GetAxis("RightH"));
        if (dir == Vector3.zero)
            return;

        transform.LookAt(transform.position + dir);
    }
}
