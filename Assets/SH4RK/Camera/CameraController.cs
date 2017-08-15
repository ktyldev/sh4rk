﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform trackedObject { get; set; }
    public float shakeMagnitude;
    public GameObject focus;

    private bool _shake = false;
    private Vector3 _offset;

    void Awake() {
        _offset = transform.position;
    }

    void Update() {
        if (trackedObject == null)
            return;

        focus.transform.position = GameManager.BindToCameraGameArea(trackedObject.transform.position);
    }

    void OnGUI() {
        if (!_shake && InputManager.controlMode.Attack()) {
            _shake = true;
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake() {
        Func<Vector3> originalPos = () => focus.transform.position + _offset;

        var elapsed = 0f;

        var duration = Player.instance.currentShark.weapon.shotDelay;

        while (elapsed < duration) {
            elapsed += Time.deltaTime;

            var percentComplete = elapsed / duration;

            var returnPos = originalPos();

            var x = returnPos.x + (shakeMagnitude * (UnityEngine.Random.value - 0.5f));
            var z = returnPos.z + (shakeMagnitude * (UnityEngine.Random.value - 0.5f));

            transform.position = new Vector3(x, returnPos.y, z);

            yield return null;
        }

        transform.position = originalPos();
        _shake = false;
    }
}
