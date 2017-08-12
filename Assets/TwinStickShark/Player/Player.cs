using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance { get; private set; }

    public GameObject shark;

    private Shark _shark;

    public Transform sharkTransform { get { return _shark.transform; } }

    void Awake() {
        if (instance != null)
            throw new System.Exception();

        instance = this;
        _shark = Instantiate(shark).GetComponent<Shark>();
    }

    // Use this for initialization
    void Start() {
        Camera.main.GetComponent<CameraController>().trackedObject = _shark.transform;
    }

    // Update is called once per frame
    void Update() {

    }
}
