using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSplash : MonoBehaviour {

    private static GameOverSplash _instance;

    public GameObject graphic;
    
    void Awake() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;
    }
    
    protected void ShowSplash() {
        Instantiate(graphic, transform);
    }

    public static void Show() {
        _instance.ShowSplash();
    }
}
