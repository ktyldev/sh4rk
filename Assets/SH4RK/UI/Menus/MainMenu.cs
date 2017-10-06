using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu {

    public GameObject optionsMenu;
    
    public void StartGame() {
        SceneManager.LoadScene("dev");
    }

    public void OptionsMenu() {
        UIManager.Instance.OpenMenu(gameObject, optionsMenu);
    }

    public void Quit() {
        Application.Quit();
    }
}
