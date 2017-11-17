using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readout : MonoBehaviour {

    public GameObject gameController;

    private Player _player;
    private EnemySpawner _enemies;
    public Text _highScore;
    public Text _score;
    public Text _wave;
    public Text _enemiesRemaining;

    void Start() {
        _player = GameObject.FindGameObjectWithTag(GameTags.Player).GetComponent<Player>();
        _enemies = gameController.GetComponent<EnemySpawner>();

        _wave.text = "Wave 1";
        _enemies.waveStart.AddListener(() => _wave.text = string.Format("Wave {0}", _enemies.currentWave));
    }

    void OnGUI() {
        _highScore.text = _player.highScore.ToString();
        _score.text = _player.score.ToString();
        _enemiesRemaining.text = _enemies.remaining.ToString();
    }
}
