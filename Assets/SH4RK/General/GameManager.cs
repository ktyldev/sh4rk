﻿using System.Collections;
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
    protected bool isGameOver = false;
    public static bool exists { get { return _instance != null; } }
    public static bool paused { get { return exists && _instance.isPaused; } }
    public static bool gameIsOver { get { return _instance.isGameOver; } }

    public static UnityEvent onPause { get; private set; }
    public static UnityEvent onUnPause { get; private set; }
    public static UnityEvent gameOver { get; private set; }

    void Awake() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;

        onPause = new UnityEvent();
        onUnPause = new UnityEvent();
        gameOver = new UnityEvent();

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
        Debug.Log("GameOver!");
        gameOver.Invoke();
        _instance.isGameOver = true;
        _instance.PauseGame();
    }

    public static void Reload() {
        var scene = SceneManager.GetActiveScene().buildIndex;
        _instance.UnpauseGame();
        _instance.isGameOver = false;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    
    public static Vector3 BindToGameArea(Vector3 position) {
        return _instance.movementBounds.Contains(position) ? position : _instance.movementBounds.ClosestPoint(position);
    }

    public static Vector3 BindToCameraGameArea(Vector3 position) {
        return _instance.cameraBounds.Contains(position) ? position : _instance.cameraBounds.ClosestPoint(position);
    }
}
