using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject optionsMenu;
    
    public void QuitToMainMenu() {
        SceneManager.LoadScene("main_menu");
    }

    public void OptionsMenu() {
        UIManager.instance.OpenMenu(gameObject, optionsMenu);
    }

    public void Resume() {
        GameManager.TogglePause();
    }
}
