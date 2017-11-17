using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField]
    public GameObject _shark;

    public Shark Shark { get; private set; }
    
    public int score { get; private set; }
    public int highScore { get; private set; }

    void Awake() {
        if (!PlayerPrefs.HasKey(GameTags.HighScore)) {
            PlayerPrefs.SetInt(GameTags.HighScore, 0);
        }

        highScore = PlayerPrefs.GetInt(GameTags.HighScore);
        Shark = Instantiate(_shark).GetComponent<Shark>();
    }
    
    void Start() {
        Camera.main.GetComponent<CameraController>().trackedObject = Shark.transform;

        GameManager.gameOver.AddListener(() => {
            if (score > highScore) {
                PlayerPrefs.SetInt(GameTags.HighScore, score);
            }
        });
    }

    public void AddScore(int amount) {
        score += amount;
    }
}
