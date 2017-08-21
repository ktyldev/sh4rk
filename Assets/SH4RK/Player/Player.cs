using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private const string high_score = "high_score";

    public static Player instance { get; private set; }

    public GameObject shark;

    public Shark currentShark { get; private set; }

    public Transform sharkTransform { get { return currentShark.transform; } }
    public int score { get; private set; }
    public int highScore { get; private set; }

    void Awake() {
        if (!PlayerPrefs.HasKey(high_score)) {
            PlayerPrefs.SetInt(high_score, 0);
        }

        highScore = PlayerPrefs.GetInt(high_score);

        if (instance != null)
            throw new System.Exception();
        
        instance = this;
        currentShark = Instantiate(shark).GetComponent<Shark>();
    }
    
    void Start() {
        Camera.main.GetComponent<CameraController>().trackedObject = currentShark.transform;

        GameManager.gameOver.AddListener(() => {
            if (score > highScore) {
                PlayerPrefs.SetInt(high_score, score);
            }
        });
    }

    public void AddScore(int amount) {
        score += amount;
    }
}
