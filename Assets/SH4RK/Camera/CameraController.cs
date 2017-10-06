using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform trackedObject { get; set; }

    public float maxShakeMagnitude;
    public GameObject focus;
    public float lerp;

    private Vector3 _offset;
    private float _shakeTimeLeft;

    void Awake() {
        if (!PlayerPrefs.HasKey("camera_shake")) {
            PlayerPrefs.SetFloat("camera_shake", 0.5f);
        }

        _offset = transform.position;
    }

    void Update() {
        if (trackedObject == null)
            return;

        focus.transform.position = Vector3.Lerp(focus.transform.position, GameManager.BindToCameraGameArea(trackedObject.transform.position), lerp);

        if (_shakeTimeLeft > 0) {
            _shakeTimeLeft -= Time.deltaTime;
        }
    }

    void OnGUI() {
        if (_shakeTimeLeft > 0) {
            StartCoroutine(Shake());
        }
    }

    public void ShakeForSeconds(float seconds) {
        _shakeTimeLeft = seconds;
    }

    private IEnumerator Shake() {
        Func<Vector3> originalPos = () => focus.transform.position + _offset;

        var elapsed = 0f;

        var duration = Player.instance.currentShark.weapon.shotDelay;

        while (elapsed < duration) {
            elapsed += Time.deltaTime;

            var returnPos = originalPos();

            var shakeValue = PlayerPrefs.GetFloat("camera_shake") * maxShakeMagnitude;

            var x = returnPos.x + (shakeValue * (UnityEngine.Random.value - 0.5f));
            var z = returnPos.z + (shakeValue * (UnityEngine.Random.value - 0.5f));

            transform.position = new Vector3(x, returnPos.y, z);

            yield return null;
        }

        transform.position = originalPos();
    }
}
