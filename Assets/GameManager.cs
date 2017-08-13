using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    
    public Bounds bounds;

    void Awake() {
        if (_instance != null)
            throw new System.Exception();

        _instance = this;
    }
    
    public static void GameOver() {
        Debug.Log("GameOver!");
        Time.timeScale = 0;
        GameOverSplash.Show();
    }

    public static Vector3 BindToGameArea(Vector3 position) {
        if (_instance.bounds.Contains(position))
            return position;

        return _instance.bounds.ClosestPoint(position);
    }
}
