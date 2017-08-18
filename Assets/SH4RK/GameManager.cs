using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    
    public int resetTimer;
    public Bounds movementBounds;
    public Bounds cameraBounds;
    
    protected bool isPaused = false;
    public static bool paused { get { return _instance.isPaused; } }

    void Awake() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;
    }

    public static void TogglePause() {
        _instance.isPaused = !_instance.isPaused;
        Time.timeScale = paused ? 0 : 1;    
    }
    
    public static void GameOver() {
        TogglePause();
        Debug.Log("GameOver!");
        GameOverSplash.Show();
        _instance.Reload();
    }

    protected void Reload() {
        StartCoroutine(ReloadLevel());
    }

    private IEnumerator ReloadLevel() {
        var scene = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSecondsRealtime(resetTimer);
        TogglePause();
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public static Vector3 BindToGameArea(Vector3 position) {
        return _instance.movementBounds.Contains(position) ? position : _instance.movementBounds.ClosestPoint(position);
    }

    public static Vector3 BindToCameraGameArea(Vector3 position) {
        return _instance.cameraBounds.Contains(position) ? position : _instance.cameraBounds.ClosestPoint(position);
    }
}
