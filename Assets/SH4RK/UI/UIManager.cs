using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance { get; private set; }
    
    public GameObject pauseMenu;

    private GameObject _openMenu;

    void Start() {
        if (instance != null)
            throw new System.Exception();

        instance = this;
        
        if (GameManager.exists) {
            GameManager.onPause.AddListener(() => _openMenu = Instantiate(pauseMenu, transform));
            GameManager.onUnPause.AddListener(() => Destroy(_openMenu));
        }
    }
    
    public void OpenMenu(GameObject opener, GameObject menu) {
        var newMenu = Instantiate(menu, opener.transform.parent).GetComponent<Menu>();
        newMenu.opener = opener;
        opener.gameObject.SetActive(false);
    }
}
