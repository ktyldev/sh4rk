using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int id { get; set; }

    public GameObject shark;
    
    public Shark currentShark { get; private set; }
    public Transform sharkTransform { get { return currentShark.transform; } }
    public int score { get; private set; }

    void Awake() {
        OnAwake();
    }

    protected virtual void OnAwake() {
        currentShark = Instantiate(shark).GetComponent<Shark>();
    }
    
    public void AddScore(int amount) {
        score += amount;
    }
}
