using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Readout : MonoBehaviour {

    public GameObject gameController;

    private Player _player;
    private EnemySpawner _enemies;
    private Text _text;

    void Start() {
        _player = Player.instance;
        _text = GetComponent<Text>();
        _enemies = gameController.GetComponent<EnemySpawner>();
    }

    void OnGUI() {
        var sb = new StringBuilder();
        sb.AppendLine("Score: " + _player.score);
        sb.AppendLine("Wave: " + _enemies.currentWave);
        sb.AppendLine("Remaing: " + _enemies.remaining);

        _text.text = sb.ToString();
    }
}
