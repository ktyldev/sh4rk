using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager instance { get; private set; }
    
    public GameObject pauseMenu;

    private GameObject _openMenu;

    void Start() {
        if (instance != null)
            throw new System.Exception();

        instance = this;

        GameManager.onPause.AddListener(() => _openMenu = Instantiate(pauseMenu, transform));
        GameManager.onUnPause.AddListener(() => Destroy(_openMenu));
    }
    
    public void OpenMenu(GameObject opener, GameObject menu) {
        _openMenu = Instantiate(menu, opener.transform.parent);
        Destroy(opener);
    }
}
