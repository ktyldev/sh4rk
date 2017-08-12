using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSplash : MonoBehaviour {

    private static GameOverSplash _instance;

    public GameObject graphic;
    public int resetTimer;

    private int _current;

    void Awake() {
        _current = resetTimer;

        if (_instance != null)
            throw new System.Exception();

        _instance = this;
    }
    
    private IEnumerator ReloadLevel() {
        var scene = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSecondsRealtime(resetTimer);
        Time.timeScale = 1;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    protected void ShowSplash() {
        Instantiate(graphic, transform);
        StartCoroutine(ReloadLevel());
    }

    public static void Show() {
        _instance.ShowSplash();
    }
}
