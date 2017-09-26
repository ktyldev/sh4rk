using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    public GameObject explosion;
    public float cameraShakeTime;

    private CameraController _camera;

    void Start() {
        _camera = Camera.main.GetComponent<CameraController>();    
    }

    public void MakeExplosion(Vector3 position) {
        Instantiate(explosion, position, Quaternion.identity, transform);
        _camera.ShakeForSeconds(cameraShakeTime);
    }
}
