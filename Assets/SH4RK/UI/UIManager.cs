using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private static UIManager _instance;

    public GameObject pauseMenu;

    private GameObject _pauseMenu;

    void Start() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;
    }
    
    public static void TogglePause() {
        _instance.TogglePauseMenu();
    }

    protected void TogglePauseMenu() {
        if (_pauseMenu == null) {
            _pauseMenu = Instantiate(pauseMenu, transform);
            return;
        }

        Destroy(_pauseMenu);
    }
}
