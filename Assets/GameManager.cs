using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    void Awake() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static void GameOver() {
        Debug.Log("GameOver!");
        Time.timeScale = 0;
        GameOverSplash.Show();
    }
}
