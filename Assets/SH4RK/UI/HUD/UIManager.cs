using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager Instance { get; private set; }
    
    public GameObject pauseMenu;
    public GameObject gameOverScreen;

    private GameObject _openMenu;

    void Start() {
        if (Instance != null)
            throw new System.Exception();

        Instance = this;
        
        if (GameManager.exists) {
            GameManager.onPause.AddListener(() => _openMenu = Instantiate(pauseMenu, transform));
            GameManager.onUnPause.AddListener(() => Destroy(_openMenu));

            GameManager.gameOver.AddListener(() => _openMenu = Instantiate(gameOverScreen, transform));
        }
    }
    
    public void OpenMenu(GameObject opener, GameObject menu) {
        var newMenu = Instantiate(menu, opener.transform.parent).GetComponent<Menu>();
        newMenu.opener = opener;
        opener.gameObject.SetActive(false);
    }
}
