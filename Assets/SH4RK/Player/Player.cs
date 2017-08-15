using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance { get; private set; }

    public GameObject shark;

    public Shark currentShark { get; private set; }

    public Transform sharkTransform { get { return currentShark.transform; } }
    public int score { get; private set; }

    void Awake() {
        if (instance != null)
            throw new System.Exception();

        instance = this;
        currentShark = Instantiate(shark).GetComponent<Shark>();
    }
    
    void Start() {
        Camera.main.GetComponent<CameraController>().trackedObject = currentShark.transform;
    }

    public void AddScore(int amount) {
        score += amount;
    }
}
