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
    public static bool exists { get { return _instance != null; } }
    public static bool paused { get { return exists && _instance.isPaused; } }

    public static UnityEvent onPause { get; private set; }
    public static UnityEvent onUnPause { get; private set; }

    void Awake() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;

        onPause = new UnityEvent();
        onUnPause = new UnityEvent();

        UnpauseGame();
    }

    public static void TogglePause() {
        _instance.TogPause();
    }

    protected void TogPause() {
        if (isPaused) {
            onUnPause.Invoke();
            UnpauseGame();
        } else {
            onPause.Invoke();
            PauseGame();
        }
    }

    private void PauseGame() {
        isPaused = true;
        Time.timeScale = 0;
    }

    private void UnpauseGame() {
        isPaused = false;
        Time.timeScale = 1;
    }

    public static void GameOver() {
        _instance.PauseGame();
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
        _instance.UnpauseGame();
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public static Vector3 BindToGameArea(Vector3 position) {
        return _instance.movementBounds.Contains(position) ? position : _instance.movementBounds.ClosestPoint(position);
    }

    public static Vector3 BindToCameraGameArea(Vector3 position) {
        return _instance.cameraBounds.Contains(position) ? position : _instance.cameraBounds.ClosestPoint(position);
    }
}
