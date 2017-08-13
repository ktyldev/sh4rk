using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

    public GameObject gameController;

    private EnemySpawner _enemies;
    private Text _text;

    void Start() {
        _text = GetComponent<Text>();
        _enemies = gameController.GetComponent<EnemySpawner>();
    }

    void OnGUI() {
        _text.text = "Wave: " + _enemies.currentWave; 
    }
}
