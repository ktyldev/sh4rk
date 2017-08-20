using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour {

    public SessionManager instance { get; private set; }

    public UnityEvent gameStart;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        gameStart = new UnityEvent();
        SceneManager.sceneLoaded += (s, _) => {
            if (s.name == "dev") {
                print("Game start!");
                gameStart.Invoke();
            }
        };
    }
}
