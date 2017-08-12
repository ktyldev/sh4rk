using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance { get; private set; }

    public GameObject shark;

    private Shark _shark;

    public Transform sharkTransform { get { return _shark.transform; } }
    public int score { get; private set; }

    void Awake() {
        if (instance != null)
            throw new System.Exception();

        instance = this;
        _shark = Instantiate(shark).GetComponent<Shark>();
    }
    
    void Start() {
        Camera.main.GetComponent<CameraController>().trackedObject = _shark.transform;
    }

    public void AddScore(int amount) {
        score += amount;
        Debug.Log("Score: " + score);
    }
}
